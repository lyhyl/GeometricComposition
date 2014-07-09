using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricComposition
{
    public delegate U FuncRef<T0, out U>(ref T0 t1);
    public delegate U FuncRef<T0, T1, out U>(ref T0 t0, T1 t1);
    public delegate U FuncRef<T0, T1, T2, out U>(ref T0 t0, T1 t1, T2 t2);

    public delegate U FuncRef2<T0, T1, out U>(ref T0 t0, ref T1 t1);
    public delegate U FuncRef2<T0, T1, T2, out U>(ref T0 t0, ref T1 t1, T2 t2);

    public delegate U FuncRef3<T0, T1, T2, out U>(ref T0 t0, ref T1 t1, ref T2 t2);
}
