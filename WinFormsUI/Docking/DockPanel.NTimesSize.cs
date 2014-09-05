using System;
using System.ComponentModel;
namespace WeifenLuo.WinFormsUI.Docking
{
    partial class DockPanel
    {
        [LocalizedCategory("Category_Docking")]
        [DefaultValue(true)]
        public bool Dragable
        {
            get;
            set;
        }

        [LocalizedCategory("Category_Docking")]
        [DefaultValue(0)]
        public int NTWidth
        {
            get;
            set;
        }
        [LocalizedCategory("Category_Docking")]
        [DefaultValue(0)]
        public int NTHeight
        {
            get;
            set;
        }

        internal double GetNTimesWidth(int w, int minn)
        {
            int d = (w % NTWidth) - (NTWidth >> 1) > 0 ? 1 : 0;
            int n = Math.Max(w / NTWidth + d, minn);
            return NTWidth * n;
        }

        internal double GetNTimesHeight(int h, int minn)
        {
            int d = (h % NTHeight) - (NTHeight >> 1) > 0 ? 1 : 0;
            int n = Math.Max(h / NTHeight + d, minn);
            return NTHeight * n;
        }
    }
}
