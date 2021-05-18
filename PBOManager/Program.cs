using System;
using System.Windows.Forms;

namespace PBOManager
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] Args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (Args.Length > 0)
			{
				Application.Run((Form)(object)new PBOM_Explorer(Args[0]));
			}
			else
			{
				Application.Run((Form)(object)new PBOM_Explorer(""));
			}
		}
	}
}
