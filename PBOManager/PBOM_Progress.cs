using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PBOManager
{
	public class PBOM_Progress : Form
	{
		private IContainer components;

		private Panel PBOM_Pr_Panel;

		private ProgressBar PBOM_Pr_Bar;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				((IDisposable)components).Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			PBOM_Pr_Panel = new Panel();
			PBOM_Pr_Bar = new ProgressBar();
			((Control)PBOM_Pr_Panel).SuspendLayout();
			((Control)this).SuspendLayout();
			PBOM_Pr_Panel.set_BorderStyle((BorderStyle)1);
			((Control)PBOM_Pr_Panel).get_Controls().Add((Control)(object)PBOM_Pr_Bar);
			((Control)PBOM_Pr_Panel).set_Dock((DockStyle)5);
			((Control)PBOM_Pr_Panel).set_Location(new Point(0, 0));
			((Control)PBOM_Pr_Panel).set_Name("PBOM_Pr_Panel");
			((Control)PBOM_Pr_Panel).set_Size(new Size(216, 48));
			((Control)PBOM_Pr_Panel).set_TabIndex(0);
			((Control)PBOM_Pr_Bar).set_Location(new Point(12, 11));
			((Control)PBOM_Pr_Bar).set_Name("PBOM_Pr_Bar");
			((Control)PBOM_Pr_Bar).set_Size(new Size(191, 23));
			PBOM_Pr_Bar.set_Style((ProgressBarStyle)2);
			((Control)PBOM_Pr_Bar).set_TabIndex(1);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(216, 48));
			((Form)this).set_ControlBox(false);
			((Control)this).get_Controls().Add((Control)(object)PBOM_Pr_Panel);
			((Form)this).set_FormBorderStyle((FormBorderStyle)0);
			((Form)this).set_MaximizeBox(false);
			((Form)this).set_MinimizeBox(false);
			((Control)this).set_Name("PBOM_Progress");
			((Form)this).set_ShowIcon(false);
			((Form)this).set_ShowInTaskbar(false);
			((Form)this).set_StartPosition((FormStartPosition)0);
			((Control)this).set_Text("PBOM_Progress");
			((Form)this).set_TopMost(true);
			((Form)this).add_FormClosing(new FormClosingEventHandler(PBOM_Progress_FormClosing));
			((Control)PBOM_Pr_Panel).ResumeLayout(false);
			((Control)this).ResumeLayout(false);
		}

		public PBOM_Progress(Form ParentControl)
			: this()
		{
			InitializeComponent();
			((Control)this).set_Left(((Control)ParentControl).get_Left() + Convert.ToInt32((float)((Control)ParentControl).get_Width() / 2f) - Convert.ToInt32((float)((Control)this).get_Width() / 2f));
			((Control)this).set_Top(((Control)ParentControl).get_Top() + Convert.ToInt32((float)((Control)ParentControl).get_Height() / 2f) - Convert.ToInt32((float)((Control)this).get_Height() / 2f));
		}

		private void PBOM_Progress_FormClosing(object sender, FormClosingEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			if ((int)e.get_CloseReason() == 3)
			{
				((CancelEventArgs)e).set_Cancel(true);
			}
			else
			{
				((CancelEventArgs)e).set_Cancel(false);
			}
		}

		internal void SetProgress(int Progress, int Maximum)
		{
			PBOM_Pr_Bar.set_Style((ProgressBarStyle)1);
			PBOM_Pr_Bar.set_Minimum(0);
			PBOM_Pr_Bar.set_Maximum(Maximum);
			PBOM_Pr_Bar.set_Value(Progress);
		}
	}
}
