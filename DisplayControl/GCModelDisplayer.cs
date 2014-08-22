#region File Description
//-----------------------------------------------------------------------------
// ModelViewerControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GeometricComposition.XNALibrary;
using System.Collections.Generic;
using GeometricComposition.GCMusic;

#endregion

namespace GeometricComposition.DisplayControl
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, and displays
    /// a spinning 3D model. The main form class is responsible for loading
    /// the model: this control just displays it.
    /// </summary>
    public class GCModelDisplayer : GraphicsDeviceControl
    {
        public List<GCModel> AuxiliaryModels { set; get; }
        private GCModel model;
        private float modelRadius;
        public GCModel Model
        {
            get { return model; }
            set
            {
                model = value;
                if (model != null)
                    MeasureModel();
            }
        }

        public float VertexSize { set; get; }
        public GCModel VertexModel { set; get; }

        public Vector3[] AuxiliaryVertices { set; get; }
        public GCPitch[] AuxiliaryVerticesPitch { set; get; }

        public Camera Camera { set; get; }
        public Matrix WorldMatrix { private set; get; }
        public Matrix ViewMatrix { get { return Camera.ViewMatrix; } }
        public Matrix ProjectionMatrix { private set; get; }
        public Matrix TransformMatrix { get { return WorldMatrix * ViewMatrix * ProjectionMatrix; } }

        private VertexBuffer faceVertexBuffer = null;
        private GCEffect faceEffect;

        private RasterizerState rsCullBackFace = new RasterizerState();
        private RasterizerState rsCullNone = new RasterizerState();
        private RasterizerState rsCullForeFace = new RasterizerState();

        protected override void Initialize()
        {
            Camera = new Camera();
            VertexSize = 0.2f;

            faceEffect = new GCEffect(GraphicsDevice);
            faceVertexBuffer = new VertexBuffer(GraphicsDevice, VertexPositionNormalColor.VertexDeclaration, 3, BufferUsage.WriteOnly);

            rsCullBackFace = new RasterizerState();
            rsCullBackFace.CullMode = CullMode.CullClockwiseFace;
            rsCullNone = new RasterizerState();
            rsCullNone.CullMode = CullMode.None;
            rsCullForeFace = new RasterizerState();
            rsCullForeFace.CullMode = CullMode.CullCounterClockwiseFace;

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        #region User Control View
        private const float mouseMoveScale = 0.01f;
        private float mouseMoveX = 0, mouseMoveY = 0;
        private int prevMouseX = 0, prevMouseY = 0;
        private bool UserControllingView = false;

        private const int WHEEL_DELTA = 120;

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            modelRadius -= e.Delta / WHEEL_DELTA;
            modelRadius = Math.Max(.01f, modelRadius);
            Invalidate();
            base.OnMouseWheel(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            UserControllingView = true;
            prevMouseX = e.X;
            prevMouseY = e.Y;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (UserControllingView)
            {
                mouseMoveX += e.X - prevMouseX;
                mouseMoveY += e.Y - prevMouseY;
                prevMouseX = e.X;
                prevMouseY = e.Y;
                
                // Repaint
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            UserControllingView = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            UserControllingView = false;
            base.OnMouseLeave(e);
        }
        #endregion

        protected override void Draw()
        {
            GraphicsDevice.Clear(new Color(BackColor.R, BackColor.G, BackColor.B));
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            SetupMatrix();

            if (AuxiliaryVertices != null && AuxiliaryVertices.Length != 4)
                throw new ArgumentException("AuxiliaryVertices must has 4 Vector3");

            //Back Face
            GraphicsDevice.RasterizerState = rsCullBackFace;

            if (AuxiliaryVertices != null && VertexModel != null)
                for (int i = 0; i < 4; i++)
                    DrawVertex(AuxiliaryVertices[i]);
            if (model != null)
                DrawModel();

            //None
            GraphicsDevice.RasterizerState = rsCullNone;

            if (AuxiliaryVertices != null)
                DrawFace(AuxiliaryVertices[1], AuxiliaryVertices[2], AuxiliaryVertices[3]);

            //Fore Face
            GraphicsDevice.RasterizerState = rsCullForeFace;

            if (model != null)
                DrawModel();
            if (AuxiliaryVertices != null && VertexModel != null)
                for (int i = 0; i < 4; i++)
                {
                    DrawVertex(AuxiliaryVertices[i]);
                    DrawPitch(AuxiliaryVertices[i], AuxiliaryVerticesPitch[i]);
                }
        }

        public SpriteFont spriteFont = null;
        private SpriteBatch spriteBatch = null;
        private void DrawPitch(Vector3 p, GCPitch pitch)
        {
            Vector3 clientPos = GraphicsDevice.Viewport.Project(p, ProjectionMatrix, ViewMatrix, WorldMatrix);
            //Vector3 clientPos = Vector3.Transform(Vector3.Transform(Vector3.Transform(p, WorldMatrix), ViewMatrix), ProjectionMatrix);
            Vector2 fontPos = new Vector2(clientPos.X, clientPos.Y);

            spriteBatch.Begin();
            string pitchName = GCPitchHelper.GetName(pitch);
            //Vector2 FontOrigin = spriteFont.MeasureString(pitchName) / 2;
            spriteBatch.DrawString(spriteFont, pitchName, fontPos, Color.LightGreen, 0, Vector2.Zero, 1, SpriteEffects.None, 0.5f);
            spriteBatch.End();
        }

        private void DrawFace(Vector3 a, Vector3 b, Vector3 c)
        {
            faceEffect.World = WorldMatrix;
            faceEffect.View = ViewMatrix;
            faceEffect.Projection = ProjectionMatrix;
            faceEffect.CameraPosition = Camera.Position;
            faceEffect.DiffuseColor = Color.Red.ToVector3();
            faceEffect.SpecularColor = Color.Red.ToVector3();
            faceEffect.EmissiveColor = Color.Red.ToVector3();
            faceEffect.Alpha = 0.5f;

            Vector3 nor = Vector3.Cross(a - b, b - c);
            VertexPositionNormalColor[] data = new VertexPositionNormalColor[] {
                new VertexPositionNormalColor(a, nor, Color.Red),
                new VertexPositionNormalColor(b, nor, Color.Red),
                new VertexPositionNormalColor(c, nor, Color.Red) };
            // TODO : Color Element is useless
            faceVertexBuffer.SetData(data);
            GraphicsDevice.SetVertexBuffer(faceVertexBuffer);
            foreach (EffectPass pass in faceEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 1);
            }
        }

        private void DrawVertex(Vector3 pos)
        {
            VertexModel.Effect.World =  Matrix.CreateScale(VertexSize) * Matrix.CreateTranslation(pos) * WorldMatrix;
            VertexModel.Effect.View = ViewMatrix;
            VertexModel.Effect.Projection = ProjectionMatrix;
            VertexModel.Effect.CameraPosition = Camera.Position;
            VertexModel.Effect.DiffuseColor = Color.Gold.ToVector3();
            VertexModel.Effect.SpecularColor = Color.Gold.ToVector3();
            VertexModel.Effect.EmissiveColor = Color.Gold.ToVector3();
            VertexModel.Effect.Alpha = 1;
            VertexModel.Draw();
        }

        private void DrawModel()
        {
            Model.Effect.World = WorldMatrix;
            Model.Effect.View = ViewMatrix;
            Model.Effect.Projection = ProjectionMatrix;
            Model.Effect.CameraPosition = Camera.Position;
            Model.Effect.Alpha = 0.5f;
            Model.Draw();
        }

        private void SetupMatrix()
        {
            //World
            WorldMatrix = Matrix.CreateRotationY(mouseMoveX * mouseMoveScale) *
                Matrix.CreateRotationX(mouseMoveY * mouseMoveScale);

            //View
            Camera.Target = Vector3.Zero;
            Camera.Position = Camera.Target + new Vector3(0, modelRadius, modelRadius * 2);

            //Projection
            float aspectRatio = GraphicsDevice.Viewport.AspectRatio;
            float nearClip = modelRadius / 100;
            float farClip = modelRadius * 100;
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(1, aspectRatio, nearClip, farClip);
        }

        void MeasureModel()
        {
            modelRadius = 15;
        }
    }
}
