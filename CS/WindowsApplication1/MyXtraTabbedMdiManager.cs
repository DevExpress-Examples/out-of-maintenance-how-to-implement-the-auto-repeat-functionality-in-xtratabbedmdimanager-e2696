using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;
using DevExpress.Utils.Controls;
using DevExpress.Utils;

namespace WindowsApplication1
{
    public class MyXtraTabbedMdiManager : XtraTabbedMdiManager
    {

        public MyXtraTabbedMdiManager()
        {
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Point mousePosition = ViewInfo.TabControl.ScreenPointToControl(Control.MousePosition);
            if (InButtons(mousePosition))
                ViewInfo.HeaderInfo.Buttons.ProcessEvent(new ProcessEventEventArgs(EventType.MouseDown, new DXMouseEventArgs(MouseButtons.Left, 1, mousePosition.X, mousePosition.Y, 0)));
        }

        private bool InButtons(Point location)
        {
            DevExpress.XtraTab.ViewInfo.BaseTabHitInfo hi = CalcHitInfo(location);
            return hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeaderButtons;
        }

        protected override void OnMouseDown(DevExpress.Utils.DXMouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (InButtons(e.Location))
                StartRepeat();
        }

        protected override void OnMouseUp(DevExpress.Utils.DXMouseEventArgs e)
        {
            base.OnMouseUp(e);
            EndRepeat();
        }
        Timer timer = new Timer();

        private void StartRepeat()
        {
            timer.Enabled = true;
        }
        private void EndRepeat()
        {
            timer.Enabled = false;
        }

    }
}
