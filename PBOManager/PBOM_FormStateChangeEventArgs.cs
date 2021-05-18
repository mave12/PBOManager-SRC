using System.Windows.Forms;

namespace PBOManager
{
	public class PBOM_FormStateChangeEventArgs
	{
		private FormWindowState _State;

		public FormWindowState WindowState => _State;

		public PBOM_FormStateChangeEventArgs(FormWindowState State)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			_State = State;
		}
	}
}
