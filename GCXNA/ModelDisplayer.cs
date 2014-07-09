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

#endregion

namespace GCXNA
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, and displays
    /// a spinning 3D model. The main form class is responsible for loading
    /// the model: this control just displays it.
    /// </summary>
    public class ModelDisplayer : GraphicsDeviceControl
    {
        private Model model;
        /// <summary>
        /// Gets or sets the current model.
        /// </summary>
        public Model Model
        {
            get { return model; }

            set
            {
                model = value;

                if (model != null)
                {
                    MeasureModel();
                }
            }
        }

        // Cache information about the model size and position.
        Matrix[] boneTransforms;
        Vector3 modelCenter;
        float modelRadius;

        Stopwatch animationTimer;
        float rotationSpeedFactor = .25f;

        private bool animation = true;
        public bool Animation
        {
            set
            {
                animation = value;
                if (AnimationChange != null)
                    AnimationChange(this, new EventArgs());
            }
            get { return animation; }
        }
        public delegate void AnimaionEventHandler(object sender, EventArgs e);
        public event AnimaionEventHandler AnimationChange;

        public Camera Camera { set; get; }
        public Matrix WorldMatrix { private set; get; }
        public Matrix ViewMatrix { get { return Camera.ViewMatrix; } }
        public Matrix ProjectionMatrix { private set; get; }
        public Matrix TransformMatrix { get { return WorldMatrix * ViewMatrix * ProjectionMatrix; } }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };

            Camera = new Camera();
            Animation = true;
            animationTimer = Stopwatch.StartNew();
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            GraphicsDevice.Clear(new Color(BackColor.R, BackColor.G, BackColor.B));
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rs;
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            if (model != null)
            {
                float rotation = (float)animationTimer.Elapsed.TotalSeconds * rotationSpeedFactor;

                Camera.Target = modelCenter;
                Camera.Position = modelCenter + new Vector3(0, modelRadius, modelRadius * 2);

                float aspectRatio = GraphicsDevice.Viewport.AspectRatio;
                float nearClip = modelRadius / 100;
                float farClip = modelRadius * 100;

                WorldMatrix = Animation ? Matrix.CreateRotationY(rotation) : Matrix.Identity;
                ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(1, aspectRatio, nearClip, farClip);

                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.World = boneTransforms[mesh.ParentBone.Index] * WorldMatrix;
                        effect.View = Camera.ViewMatrix; ;
                        effect.Projection = ProjectionMatrix;
                        effect.Alpha = 0.5f;
                        effect.EnableDefaultLighting();
                        effect.PreferPerPixelLighting = true;
                        effect.SpecularPower = 16;
                    }
                    mesh.Draw();
                }
            }
        }

        /// <summary>
        /// Whenever a new model is selected, we examine it to see how big
        /// it is and where it is centered. This lets us automatically zoom
        /// the display, so we can correctly handle models of any scale.
        /// </summary>
        void MeasureModel()
        {
            // Look up the absolute bone transforms for this model.
            boneTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);

            // Compute an (approximate) model center position by
            // averaging the center of each mesh bounding sphere.
            modelCenter = Vector3.Zero;
            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[mesh.ParentBone.Index];
                Vector3 meshCenter = Vector3.Transform(meshBounds.Center, transform);
                modelCenter += meshCenter;
            }
            modelCenter /= model.Meshes.Count;

            // Now we know the center point, we can compute the model radius
            // by examining the radius of each mesh bounding sphere.
            modelRadius = 0;
            foreach (ModelMesh mesh in model.Meshes)
            {
                BoundingSphere meshBounds = mesh.BoundingSphere;
                Matrix transform = boneTransforms[mesh.ParentBone.Index];
                Vector3 meshCenter = Vector3.Transform(meshBounds.Center, transform);
                float transformScale = transform.Forward.Length();
                float meshRadius = (meshCenter - modelCenter).Length() + (meshBounds.Radius * transformScale);
                modelRadius = Math.Max(modelRadius,  meshRadius);
            }
        }
    }
}
