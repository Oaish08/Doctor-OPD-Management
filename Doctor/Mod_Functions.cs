// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports


namespace Doctor
{
	sealed class Mod_Functions
	{
		public static Rectangle GetWorkingMonitorRect()
		{
			return GetWorkingMonitorRect((IntPtr)null);
		}
		public static Rectangle GetWorkingMonitorRect(IntPtr hWnd)
		{
			if (hWnd != null)
			{
				return Screen.FromHandle(hWnd).WorkingArea;
			}
			string applicationName = System.IO.Path.GetFileName(Application.ExecutablePath);
			foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcesses())
			{
				if (process.ProcessName.Equals(applicationName))
				{
					System.Windows.Forms.Screen _sc = System.Windows.Forms.Screen.FromHandle(process.MainWindowHandle);
					return _sc.WorkingArea;
				}
			}
			return Screen.PrimaryScreen.WorkingArea;
		}
		
	}
	
}
