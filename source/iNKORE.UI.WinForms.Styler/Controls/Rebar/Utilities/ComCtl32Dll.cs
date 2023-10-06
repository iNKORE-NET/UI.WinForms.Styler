using System;
using System.Runtime.InteropServices;

namespace iNKORE.UI.WinForms.Styler.Controls.Rebar.Utilities
{
	/// <summary>
	/// Summary description for ComCtl32Dll.
	/// </summary>
	public class ComCtl32Dll
	{
		public ComCtl32Dll()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[DllImport("ComCtl32.dll")]
		public static extern IntPtr ImageList_Create(int cx, int cy, uint flags, int cInitial, int cGrow);
		
		[DllImport("ComCtl32.dll")]
		public static extern bool ImageList_Destroy(IntPtr himl);
		
		[DllImport("ComCtl32.dll")]
		public static extern int ImageList_GetImageCount(IntPtr himl);
		
		[DllImport("ComCtl32.dll")]
		public static extern bool InitCommonControlsEx(ref INITCOMMONCONTROLSEX ComCtls);
	}
}
