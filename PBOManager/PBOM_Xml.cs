using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PBOManager
{
	[Serializable]
	[XmlRoot("Window")]
	public class PBOM_Xml
	{
		[XmlElement("Left")]
		public int X;

		[XmlElement("Top")]
		public int Y;

		[XmlElement("Width")]
		public int W;

		[XmlElement("Height")]
		public int H;

		[XmlElement("State")]
		public FormWindowState State;
	}
}
