using Microsoft.Xna.Framework;
using System;

namespace GeometricComposition.XNALibrary
{
    public class Camera
    {
        public Camera()
        {
            Position = Vector3.Zero;
            Target = Vector3.UnitX;
        }
        public Camera(Vector3 pos)
        {
            Position = pos;
            Target = pos == Vector3.UnitX ? Vector3.Zero : Vector3.UnitX;
        }
        public Camera(Vector3 pos, Vector3 tar)
        {
            if (pos == tar)
                throw new ArgumentException("Position and Target cannot be the same!");
            Position = pos;
            Target = tar;
        }
        private Vector3 position;
        public Vector3 Position
        {
            set
            {
                position = value;
                if (position == target)
                    target += Vector3.UnitX;
            }
            get { return position; }
        }
        private Vector3 target;
        public Vector3 Target
        {
            set
            {
                target = value;
                if (position == target)
                    target += Vector3.UnitX;
            }
            get { return target; }
        }
        public Matrix ViewMatrix
        { get { return Matrix.CreateLookAt(Position, Target, Vector3.Up); } }
    }
}
