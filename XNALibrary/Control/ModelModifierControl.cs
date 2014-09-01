namespace GeometricComposition.XNALibrary.Control
{
    public abstract class ModelModifierControl : System.Windows.Forms.Control
    {
        public ModelModifierControl() { }
        public abstract T GetValue<T>();
        public abstract void SetValue<T>(T v);
    }
}
