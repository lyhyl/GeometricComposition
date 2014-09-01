using Microsoft.Xna.Framework;
using System;

namespace GeometricComposition.XNALibrary.Model
{
    public class BoundingSphere
    {
        public float Radius;
        public Vector3 Center;

        public BoundingSphere(Vector3 center, float radius)
        {
            AllocRes();

            Radius = radius;
            Center = center;
        }

        public BoundingSphere(Vector3[] vs)
        {
            AllocRes();

            Update(vs);
        }

        private void AllocRes()
        {
            Center = Vector3.Zero;
            center_to_aff = Vector3.Zero;
            center_to_point = Vector3.Zero;

            lambdas = new float[3 + 1];
        }

        private float radius_square;
        private float[] lambdas;
        private float dist_to_aff, dist_to_aff_square;
        private Vector3 center_to_aff;
        private Vector3 center_to_point;
        private Subspan support;

        private float Eps = 1e-14f;

        private Vector3[] vertices;

        public void Update(Vector3[] vs)
        {
            vertices = vs;
            update();
            vertices = null;
        }

        private void update()
        {
            initializeUpdate();

            while (true)
            {
                while ((dist_to_aff = (float)Math.Sqrt(dist_to_aff_square = support.shortest_vector_to_span(Center, ref center_to_aff))) <= Eps * Radius)
                    // We are closer than Eps * radius_square, so we try a drop:
                    if (!successful_drop())
                    {
                        // If that is not possible, the center lies in the convex hull
                        // and we are done.
                        return;
                    }

                // determine how far we can walk in direction center_to_aff
                // without losing any point ('stopper', say) in S:
                int stopper;
                float scale;
                find_stop_fraction(out stopper, out scale);

                // Note: In theory, the following if-statement should simply read
                //
                //  if (stopper >= 0) {
                //    // ...
                //
                // However, due to rounding errors, it may happen in practice that
                // stopper is nonnegative and the support is already full (see #14);
                // in this casev we cannot add yet another point to the support.
                //
                // Therefore, the condition reads:
                if (stopper >= 0 && support.Size <= 3)
                {
                    // stopping point exists

                    // walk as far as we can
                    Center += scale * center_to_aff;

                    // update the radius
                    Vector3 stop_point = vertices[support.AnyMember];
                    radius_square = (stop_point - Center).LengthSquared();
                    Radius = (float)Math.Sqrt(radius_square);

                    // and add stopper to support
                    support.add_point(stopper);
                }
                else
                {
                    //  we can run unhindered into the affine hull
                    Center += center_to_aff;

                    // update the radius:
                    Vector3 stop_point = vertices[support.AnyMember];
                    radius_square = (stop_point - Center).LengthSquared();
                    Radius = (float)Math.Sqrt(radius_square);

                    // Theoretically, the distance to the affine hull is now zero
                    // and we would thus drop a point in the next iteration.
                    // For numerical stability, we don't rely on that to happen but
                    // try to drop a point right now:
                    if (!successful_drop())
                    {
                        // Drop failed, so the center lies in conv(support) and is thus
                        // optimal.
                        return;
                    }
                }
            }
        }

        private void find_stop_fraction(out int stopper, out float scale)
        {
            // We would like to walk the full length of center_to_aff ...
            scale = 1;
            stopper = -1;

            // ... but one of the points in S might hinder us:
            for (int i = 0; i < vertices.Length; ++i)
                if (!support.IsMember(i))
                {
                    // compute vector center_to_point from center to the point S[i]:
                    center_to_point = vertices[i] - Center;

                    float dir_point_prod = Vector3.Dot(center_to_aff, center_to_point);

                    // we can ignore points beyond support since they stay
                    // enclosed anyway:
                    if (dist_to_aff_square - dir_point_prod
                        // make new variable 'radius_times_dist_to_aff'? !
                        < Eps * Radius * dist_to_aff)
                        continue;

                    // compute the fraction we can walk along center_to_aff until
                    // we hit point S[i] on the boundary:
                    // (Better don't try to understand this calculus from the code,
                    //  it needs some pencil-and-paper work.)
                    float bound = radius_square;
                    bound -= Vector3.Dot(center_to_point, center_to_point);
                    bound /= 2 * (dist_to_aff_square - dir_point_prod);

                    // take the smallest fraction:
                    if (bound < scale)
                    {
                        scale = bound;
                        stopper = i;
                    }
                }
        }

        private bool successful_drop()
        {
            // find coefficients of the affine combination of center:
            support.find_affine_coefficients(Center, lambdas);

            // find a non-positive coefficient:
            int smallest = 0; // Note: assignment prevents compiler warnings.
            float minimum = 1;
            for (int i = 0; i < support.Size; ++i)
                if (lambdas[i] < minimum)
                {
                    minimum = lambdas[i];
                    smallest = i;
                }

            // drop a point with non-positive coefficient, if any:
            if (minimum <= 0)
            {
                support.remove_point(smallest);
                return true;
            }
            return false;
        }

        private void initializeUpdate()
        {
            // set center to the first point in S:
            Center = vertices[0];

            // find farthest point:
            radius_square = 0;
            int farthest = 0; // Note: assignment prevents compiler warnings.
            for (int i = 1; i < vertices.Length; ++i)
            {
                // compute squared distance from center to S[j]:
                float dist = (vertices[i] - Center).LengthSquared();

                // enlarge radius if needed:
                if (dist >= radius_square)
                {
                    radius_square = dist;
                    farthest = i;
                }
                Radius = (float)Math.Sqrt(radius_square);
            }

            // initialize support to the farthest point:
            support = new Subspan(vertices, farthest);
        }
    }
}
