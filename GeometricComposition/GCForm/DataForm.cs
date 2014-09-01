using GeometricComposition.GCMath;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GeometricComposition.GCForm
{
    public partial class DataForm : DockingForm
    {
        private const string NoAction = "";
        private const string GenerateActionName = "Generate data";
        private const string RefreshActionName = "Refresh data";

        private const string SortFPPPointPitchName = "Point Pitch";
        private const string SortFPPFaceName = "Face";
        private const string SortFPPDistanceName = "Distance";

        private string CurrentActionName = NoAction;

        private SortFPPOptions SortFPPTypeA = SortFPPOptions.PointID;
        private SortFPPOptions SortFPPTypeB = SortFPPOptions.Distance;

        public DataForm(Commander com)
            : base(com)
        {
            InitializeComponent();

            SortFPPComboBoxA.Text = SortFPPPointPitchName;
            SortFPPComboBoxB.Text = SortFPPDistanceName;
        }

        private void GenerateData(GCFile file)
        {
            Commander.StartAction(CurrentActionName);
            ReadVertices(file);
            Commander.ReportActionProgress(CurrentActionName, 20);
            GenerateFaces();
            Commander.ReportActionProgress(CurrentActionName, 40);
            GenerateFacePointPairs();
            Commander.ReportActionProgress(CurrentActionName, 60);
            SortFacePointPairs(SortFPPTypeA);
            Commander.ReportActionProgress(CurrentActionName, 80);
            DisplayPairsTreeInvoke();
            Commander.ReportActionProgress(CurrentActionName, 99);
            WriteCache(file);
            Commander.CompleteAction(CurrentActionName);
            CurrentActionName = NoAction;
        }

        private void FacePointTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GCFacePointPair fpp = e.Node.Tag as GCFacePointPair;
            if (fpp != null)
                DisplayFPP(fpp);
        }

        private void DisplayFPP(GCFacePointPair fpp)
        {
            Commander.DisplayExtraPoints(fpp.Point, fpp.Face.PointA, fpp.Face.PointB, fpp.Face.PointC);
            Commander.DisplayExtraPointsPitch(fpp.Point.ID, fpp.Face.PointA.ID, fpp.Face.PointB.ID, fpp.Face.PointC.ID);
        }

        public override void HandleSelectedFileChanged(object sender, SelectedFileChangedEventArg e)
        {
            ClearData();
            if (e.File == null)
                return;
            if (e.File.FPPCache != null)
                DisplayPairsTree(e.File.FPPCache);
            else
            {
                CurrentActionName = GenerateActionName;
                GenerateData(e.File);
            }
        }

        private void SortFPPComboBoxA_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortFPPComboBoxB.Items.Clear();
            switch (SortFPPComboBoxA.Text)
            {
                case SortFPPPointPitchName:
                    SortFPPTypeA = SortFPPOptions.PointID;
                    SortFPPComboBoxB.Items.Add(SortFPPDistanceName);
                    SortFPPComboBoxB.Text = SortFPPDistanceName;
                    SortFPPTypeB = SortFPPOptions.Distance;
                    break;
                case SortFPPDistanceName: 
                    SortFPPTypeA = SortFPPOptions.Distance;
                    SortFPPComboBoxB.Items.Add(SortFPPPointPitchName);
                    SortFPPComboBoxB.Text = SortFPPPointPitchName;
                    SortFPPTypeB = SortFPPOptions.PointID;
                    break;
            }
        }

        private void SortFPPComboBoxB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SortFPPComboBoxB.Text)
            {
                case SortFPPPointPitchName: SortFPPTypeB = SortFPPOptions.PointID; break;
                case SortFPPDistanceName: SortFPPTypeB = SortFPPOptions.Distance; break;
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            CurrentActionName = RefreshActionName;
            if (Commander.CurrentFile == null)
                return;
            Commander.CurrentFile.FPPCache = null;
            ClearData();
            GenerateData(Commander.CurrentFile);
        }
    }
}
