using System.Collections;

namespace PBOManager
{
	public class PBOM_DragFileEventArgs
	{
		private Hashtable _DragNodes;

		private string _Signature;

		private string[] _FilesToDrag;

		public string[] FilesToDrag => _FilesToDrag;

		public string Signature => _Signature;

		public Hashtable DragNodes => _DragNodes;

		public PBOM_DragFileEventArgs(Hashtable DragNodes, string[] Files, string Signature)
		{
			_DragNodes = DragNodes;
			_FilesToDrag = Files;
			_Signature = Signature;
		}
	}
}
