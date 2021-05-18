using System;
using System.Runtime.InteropServices;

namespace PBOManager
{
	internal class Win32
	{
		public const uint SHGFI_ICON = 256u;

		public const uint SHGFI_LARGEICON = 0u;

		public const uint SHGFI_SMALLICON = 1u;

		public const uint SHGFI_USEFILEATTRIBUTES = 16u;

		[DllImport("Shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

		[DllImport("User32.dll")]
		public static extern int DestroyIcon(IntPtr hIcon);
	}
}
