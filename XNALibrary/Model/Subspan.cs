using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GeometricComposition.XNALibrary.Model
{
    internal class Subspan
    {
        // a const-reference to the set S
        Vector3[] vertices;
        // S[i] in M iff membership[i]
        bool[] membership;
        // ambient dimension (not to be
        // confused with the rank r,
        // see below)

        // Entry i of members contains the index into S of the i-th point
        // in M.  The point members[r] is called the "origin."
        int[] members;

        // member fields for maintaining the QR-decomposition:

        // (3 x 3)-matrices Q
        float[][] Q, R;
        // (orthogonal) and R (upper
        // triangular); notice that
        // e.g.  Q[j][i] is the element
        // in row i and column j

        // needed for rank-1 update
        Vector3 u, w;
        // the rank of R (i.e. #points - 1)
        int r;

        public Subspan(Vector3[] vs, int index)
        {
            vertices = vs;

            membership = new bool[vertices.Length];
            members = new int[4];

            // allocate storage for Q, R, u, and w:
            Q = new float[3][];
            R = new float[3][];
            for (int i = 0; i < 3; i++)
            {
                Q[i] = new float[3];
                R[i] = new float[3];
            }

            u = w = Vector3.Zero;

            // initialize Q to the identity matrix:
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    Q[i][j] = (i == j) ? 1 : 0;

            members[r = 0] = index;
            membership[index] = true;
        }

        internal int Size { get { return r + 1; } }
        internal int AnyMember { get { return members[r]; } }

        internal bool IsMember(int i) { return membership[i]; }
        private int global_index(int i) { return members[i]; }

        internal float shortest_vector_to_span(Vector3 p, ref Vector3 w)
        {
            // compute vector from p to origin, i.e., w = origin - p:
            w = vertices[members[r]] - p;

            // remove projections of w onto the affine hull:
            for (int i = 0; i < r; ++i)
            {
                float scale = GCMath.InnerProduct(w, Q[i]);

                w.X -= scale * Q[i][0];
                w.Y -= scale * Q[i][1];
                w.Z -= scale * Q[i][2];
            }

            return Vector3.Dot(w, w);
        }

        internal void find_affine_coefficients(Vector3 p, float[] lambdas)
        {
            float[] _w;

            // compute relative position of p, i.e., u = p - origin:
            u = p - vertices[members[r]];

            // calculate Q^T u into w:
            _w = new float[] { GCMath.InnerProduct(u, Q[0]), GCMath.InnerProduct(u, Q[1]), GCMath.InnerProduct(u, Q[2]) };

            // We compute the coefficients by backsubstitution.  Notice that
            //
            //     c = \sum_{i\in M} \lambda_i (S[i] - origin)
            //       = \sum_{i\in M} \lambda_i S[i] + (1-s) origin
            //
            // where s = \sum_{i\in M} \lambda_i.-- We compute the coefficient
            // (1-s) of the origin in the variable origin_lambda:
            float origin_lambda = 1;
            for (int j = r - 1; j >= 0; --j)
            {
                for (int k = j + 1; k < r; ++k)
                    _w[j] -= lambdas[k] * R[k][j];
                origin_lambda -= lambdas[j] = _w[j] / R[j][j];
            }
            // The r-th coefficient corresponds to the origin (cf. remove_point()):
            lambdas[r] = origin_lambda;

            w = new Vector3(_w[0], _w[1], _w[2]);
        }

        internal void add_point(int index)
        {
            // compute S[i] - origin into u:
            u = vertices[index] - vertices[members[r]];

            // appends new column u to R and updates QR-decomposition,
            // routine work with old r:
            append_column();

            // move origin index and insert new index:
            membership[index] = true;
            members[r + 1] = members[r];
            members[r] = index;
            ++r;
        }

        internal void remove_point(int local_index)
        {
            membership[global_index(local_index)] = false;

            if (local_index == r)
            {
                // origin must be deleted

                // We choose the right-most member of Q, i.e., column r-1 of R,
                // as the new origin.  So all relative vectors (i.e., the
                // columns of "A = QR") have to be updated by u:= old origin -
                // S[global_index(r-1)]:
                u = vertices[members[r]] - vertices[global_index(r - 1)];

                --r;

                special_rank_1_update();
            }
            else
            {
                // general case: delete column from R

                //  shift higher columns of R one step to the left
                float[] dummy = R[local_index];
                for (int j = local_index + 1; j < r; ++j)
                {
                    R[j - 1] = R[j];
                    members[j - 1] = members[j];
                }
                members[r - 1] = members[r];  // shift down origin
                R[--r] = dummy;             // relink trash column

                // zero out subdiagonal entries in R
                hessenberg_clear(local_index);
            }
        }

        private void hessenberg_clear(int pos)
        {
            //  clear new subdiagonal entries
            for (; pos < r; ++pos)
            {
                //  pos is the column index of the entry to be cleared

                //  compute Givens coefficients c,s
                float c, s;
                givens(out c, out s, R[pos][pos], R[pos][pos + 1]);

                //  rotate partial R-rows (of the first pair, only one entry is
                //  needed, the other one is an implicit zero)
                R[pos][pos] = c * R[pos][pos] + s * R[pos][pos + 1];
                //  (then begin at posumn pos+1)
                for (int j = pos + 1; j < r; ++j)
                {
                    float a = R[j][pos];
                    float b = R[j][pos + 1];
                    R[j][pos] = c * a + s * b;
                    R[j][pos + 1] = c * b - s * a;
                }

                //  rotate Q-columns
                for (int i = 0; i < 3; ++i)
                {
                    float a = Q[pos][i];
                    float b = Q[pos + 1][i];
                    Q[pos][i] = c * a + s * b;
                    Q[pos + 1][i] = c * b - s * a;
                }
            }
        }

        private void givens(out float c, out float s, float a, float b)
        {
            if (b == 0)
            {
                c = 1;
                s = 0;
            }
            else if (Math.Abs(b) > Math.Abs(a))
            {
                float t = a / b;
                s = 1 / (float)Math.Sqrt(1 + t * t);
                c = s * t;
            }
            else
            {
                float t = b / a;
                c = 1 / (float)Math.Sqrt(1 + t * t);
                s = c * t;
            }
        }

        private void special_rank_1_update()
        {
            //  compute w = Q^T * u
            float[] _w = new float[] { GCMath.InnerProduct(u, Q[0]), GCMath.InnerProduct(u, Q[1]), GCMath.InnerProduct(u, Q[2]) };

            //  rotate w down to a multiple of the first unit vector;
            //  the operations have to be recorded in R and Q
            for (int k = 2; k > 0; --k)
            {
                //  k is the index of the entry to be cleared
                //  with the help of entry k-1

                //  compute Givens coefficients c,s
                float c, s;
                givens(out c, out s, _w[k - 1], _w[k]);

                //  rotate w-entry
                _w[k - 1] = c * _w[k - 1] + s * _w[k];

                //  rotate two R-rows;
                //  the first column has to be treated separately
                //  in order to account for the implicit zero in R[k-1][k]
                R[k - 1][k] = -s * R[k - 1][k - 1];
                R[k - 1][k - 1] *= c;
                for (int j = k; j < r; ++j)
                {
                    float a = R[j][k - 1];
                    float b = R[j][k];
                    R[j][k - 1] = c * a + s * b;
                    R[j][k] = c * b - s * a;
                }

                //  rotate two Q-columns
                for (int i = 0; i < 3; ++i)
                {
                    float a = Q[k - 1][i];
                    float b = Q[k][i];
                    Q[k - 1][i] = c * a + s * b;
                    Q[k][i] = c * b - s * a;
                }
            }

            //  add w * (1,...,1)^T to new R
            //  which means simply to add u[0] to each column
            //  since the other entries of u have just been eliminated
            for (int j = 0; j < r; ++j)
                R[j][0] += _w[0];

            //  clear subdiagonal entries
            hessenberg_clear(0);

            w = new Vector3(_w[0], _w[1], _w[2]);
        }

        private void append_column()
        {
            //  compute new column R[r] = Q^T * u
            R[r] = new float[] { GCMath.InnerProduct(u, Q[0]), GCMath.InnerProduct(u, Q[1]), GCMath.InnerProduct(u, Q[2]) };

            //  zero all entries R[r][dim-1] down to R[r][r+1]
            for (int j = 3 - 1; j > r; --j)
            {
                //  j is the index of the entry to be cleared
                //  with the help of entry j-1

                //  compute Givens coefficients c,s
                float c, s;
                givens(out c, out s, R[r][j - 1], R[r][j]);

                //  rotate one R-entry (the other one is an implicit zero)
                R[r][j - 1] = c * R[r][j - 1] + s * R[r][j];

                //  rotate two Q-columns
                for (int i = 0; i < 3; ++i)
                {
                    float a = Q[j - 1][i];
                    float b = Q[j][i];
                    Q[j - 1][i] = c * a + s * b;
                    Q[j][i] = c * b - s * a;
                }
            }
        }
    }
}
