using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Reflection;

namespace GeometricComposition.XNALibrary
{
    public class GCEffect : Effect
    {
        #region matrix
        public Matrix World
        {
            set { Parameters[0].SetValue(value); }
            get { return Parameters[0].GetValueMatrix(); }
        }
        public Matrix View
        {
            set { Parameters[1].SetValue(value); }
            get { return Parameters[1].GetValueMatrix(); }
        }
        public Matrix Projection
        {
            set { Parameters[2].SetValue(value); }
            get { return Parameters[2].GetValueMatrix(); }
        }
        #endregion

        public Vector3 CameraPosition
        {
            set { Parameters[3].SetValue(value); }
            get { return Parameters[3].GetValueVector3(); }
        }

        #region material
        public Vector3 DiffuseColor
        {
            set { Parameters[4].SetValue(value); }
            get { return Parameters[4].GetValueVector3(); }
        }
        public Vector3 EmissiveColor
        {
            set { Parameters[5].SetValue(value); }
            get { return Parameters[5].GetValueVector3(); }
        }
        public Vector3 SpecularColor
        {
            set { Parameters[6].SetValue(value); }
            get { return Parameters[6].GetValueVector3(); }
        }
        public Single SpecularPower
        {
            set { Parameters[7].SetValue(value); }
            get { return Parameters[7].GetValueSingle(); }
        }
        public Single Alpha
        {
            set { Parameters[8].SetValue(value); }
            get { return Parameters[8].GetValueSingle(); }
        }
        #endregion

        public Vector3 AmbientColor
        {
            set { Parameters[9].SetValue(value); }
            get { return Parameters[9].GetValueVector3(); }
        }

        #region light
        public Int32 LightType
        {
            set { Parameters[10].SetValue(value); }
            get { return Parameters[10].GetValueInt32(); }
        }
        public Vector3 LightPosition
        {
            set { Parameters[11].SetValue(value); }
            get { return Parameters[11].GetValueVector3(); }
        }
        public Vector3 LightDiffuseColor
        {
            set { Parameters[12].SetValue(value); }
            get { return Parameters[12].GetValueVector3(); }
        }
        public Vector3 LightSpecularColor
        {
            set { Parameters[13].SetValue(value); }
            get { return Parameters[13].GetValueVector3(); }
        }
        public Single LightDistanceSquared
        {
            set { Parameters[14].SetValue(value); }
            get { return Parameters[14].GetValueSingle(); }
        }
        #endregion

        public GCEffect(GraphicsDevice device) : base(device, effectCode()) { }

        private static byte[] _code;
        private static byte[] effectCode()
        {
            if (_code == null)
                try
                {
                    Assembly _assembly = Assembly.GetExecutingAssembly();
                    Stream _stream = _assembly.GetManifestResourceStream("GeometricComposition.XNALibrary.GCEffect.xnb");
                    //
                    // http://www.cnblogs.com/crazylights/archive/2010/11/03/1868260.html
                    // It works ! but I do not know why ...
                    //
                    const int magic = 168;
                    _code = new byte[_stream.Length - magic];
                    _stream.Seek(magic, SeekOrigin.Begin);
                    _stream.Read(_code, 0, _code.Length);
                }
                catch (Exception e)
                {
                    throw new Exception("Error ocurred during accessing GCEffect resources!", e);
                }
            return _code;
        }
    }
}
