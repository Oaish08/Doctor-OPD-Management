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

using System.Runtime.InteropServices;


namespace Doctor
{
	sealed class Module1
	{
		public enum PenStatus
		{
			PEN_DOWN = 1,
			PEN_MOVE,
			PEN_UP,
			PEN_HOVER
		}
		
		public enum PenCalibrationStatus
		{
			CAL_TOP = 0,
			CAL_BOTTOM,
			CAL_END
		}
		
		public enum StationPosition
		{
			TOP = 1,
			LEFT,
			RIGHT,
			BOTTOM
		}
		
		public enum MakerState
		{
			RED = 81,
			GREEN = 82,
			YELLOW = 83,
			BLUE = 84,
			PEN_UP = 15,
			PURPLE = 86,
			BLACK = 88,
			ERASER_CAP = 89,
			LOW_BATTERY = 90,
			BIG_ERASER = 92
		}
		
		public enum PENSTYLE
		{
			PENSTYLE_NORMAL = 0,
			PENSTYLE_BRUSH,
			PENSTYLE_HIGHLIGHT
		}
		
		public enum GestureMessage
		{
			GESTURE_RIGHT_LEFT = 100,
			GESTURE_LEFT_RIGHT,
			GESTURE_UP_DOWN,
			GESTURE_DOWN_UP,
			GESTURE_CIRCLE_CLOCKWISE,
			GESTURE_DOUBLECIRCLE_CLOCKWISE,
			GESTURE_CIRCLE_COUNTERCLOCKWISE,
			GESTURE_CROSS_DOWN,
			GESTURE_CROSS_UP,
			GESTURE_CROSS_LEFT,
			GESTURE_CROSS_RIGHT,
			GESTURE_ZIGZAG,
			GESTURE_CLICK,
			GESTURE_DOUBLECLICK,
			GESTURE_TRIPPLECLICK,
			GESTURE_LONGCLICK,
			GESTURE_DOUBLECROSS_DOWN,
			GESTURE_DOUBLECROSS_UP,
			GESTURE_DOUBLECROSS_LEFT,
			GESTURE_DOUBLECROSS_RIGHT,
			GESTURE_DOUBLECIRCLE_COUNTERCLOCKWISE
		}
		
		public const int WM_RETURNMESSAGE = 0x400 + 1; //pen message
		public const int WM_GESTUREMESSAGE = 0x400 + 2; //gesture message
		public const int WM_PENCONDITION = 0x400 + 3; //gesture message
		public const int WM_ERASER_ON = 0x400 + 4;
		
		public const int WM_SHOWLIST = 0x400 + 5; //di show list
		public const int WM_DI_START = 0x400 + 6; //di start
		public const int WM_DI_OK = 0x400 + 7; //di ok
		public const int WM_DI_FAIL = 0x400 + 8; //di fail
		public const int WM_DI_REMOVEOK = 0x400 + 9; //di remove ok
		public const int WM_DI_ACC = 0x400 + 10; //di acc
		public const int WM_DISCONNECTPEN = 0x400 + 11; //Disconnect pen
		public const int WM_DOWNLOAD_COMPLEATE = 0x400 + 12; //di download complete
		public const int WM_DI_NEWPAGE = 0x400 + 13; //New Page
		public const int WM_DI_PAGE_NUM = 0x400 + 14; //di duplicate
		public const int WM_DI_CHANGE_STATION = 0x400 + 15; //di duplicate
		public const int WM_DISCONNECTUSB = 0x400 + 16; //Disconnect Usb
		public const int WM_DI_DUPLICATE = 0x400 + 17; //Duplicate Button event
		public const int WM_MCU_VERSION = 0x400 + 18; //Duplicate Button event
		public const int WM_TIMERRESET = 0x400 + 19; //Duplicate Button event
		public const int WM_LOST_PEN = 0x400 + 20; //Disconnect by timer cannot receive pendata during 30sec
		
		public enum DICOMMAND
		{
			SHOWLIST = 1,
			OPENFILE,
			OPENFOLDER,
			REMOVEFILE,
			REMOVEFOLDER,
			REMOVEALL,
			SETDATETIME,
			SHOWDATETIME,
			SHOWDISKFREESPACE,
			SHOWDEVICEID,
			SHOWTEMPFILE,
			CHANGEMODETOREAL,
			CHANGEMODETOT2
		}
		public enum WorkAreaType
		{
			LETTER = 1,
			A4,
			A5,
			B5,
			B6
		}
		public static System.Drawing.Rectangle Cali_LETTER = new System.Drawing.Rectangle(1737, 541, 5445 - 1737, 4818 - 541); //(1700, 500, 5470, 4800)
		public static System.Drawing.Rectangle Cali_A4 = new System.Drawing.Rectangle(1768, 563, 5392 - 1768, 5160 - 563); //(1750, 450, 5450, 5120)
		public static System.Drawing.Rectangle Cali_A5 = new System.Drawing.Rectangle(2341, 542, 4865 - 2341, 3631 - 542); //(2300, 540, 4880, 3625)
		public static System.Drawing.Rectangle Cali_B5 = new System.Drawing.Rectangle(2027, 561, 5183 - 2027, 4462 - 561); //(2000, 500, 5200, 4430)
		public static System.Drawing.Rectangle Cali_B6 = new System.Drawing.Rectangle(2500, 544, 4704 - 2500, 3154 - 544); //(2460, 530, 4660, 3170)
		
		//' Structure for receiving pen data
		internal struct _pen_rec
		{
			public int X; // X (before calibration)
			public int Y; // Y (before calibration)
			public short T; // temperature (celcious)
			public int P; // pressure ( 0 ~ 900 )
			public float TX; //  X (after calibration)
			public float TY; // Y (after calibration)
			public int Func; //pen button clicked
			public int ModelCode; //Device Model Code 2: Equil Smart Pen 3:Equil Smart Pen 2 4:Equil Smart Marker
			public int Sensor_dis; //distance between sensors (need not to know)
			public int HWVer; //HWVer
			public int MCU1; //MCU1 (need not to know)
			public int MCU2; //MCU2 (need not to know)
			public int PenStatus; //Pen tip (1: Down 2:Move 3:Up 4:Hover)
			public int IRGAP; //sensor property (need not to know)
			//SmartMaker Variable Add
			public int PenTiming; //Maker State Data
			public int bRight;
			public int Station_Position;
			public int drawRectX;
			public int drawRectY;
		}
		public struct PENConditionData
		{
			public int modelCode;
			public int pen_alive; //Pen alive
			public int battery_station;
			public int battery_pen;
			public int StationPosition;
			public int usbConnect;
		}
		//    Public Declare Function FindPort Lib "PNFPenLib.dll" () As Boolean 'scan port from device
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void OnDisconnect(int Terminate);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)] //Search for USB connection
		public static extern bool FindDevice();
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void PortSearch();
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetReciveHandle(System.IntPtr hWnd);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetDrawRect(double Width, double Height);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetDrawHandle(System.IntPtr hWnd);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern bool CheckConnect();
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetCalibMode(bool bCalibMode);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetPenDownThreshold(int iDown);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetCalibration_Top(double x, double y);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetCalibration_Bottom(double x, double y);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetCalibration_End();
		//for calibration by form
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetCalibration_EndWithDest(int tx, int ty, int bx, int by);
		
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetAudio(byte _AudioMode, byte _AudioVolume);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern byte GetAudioMode();
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern byte GetAudioVolume();
		
		
		/// <summary>
		/// Memory Import Apis '''''
		/// </summary>
		/// <remarks></remarks>
		///
		
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)] //' Intialize nState =0:BT, nSate=1 USB
		public static extern int StartDISetup(int nState);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetDI(int nState, int nFolder, int nFile);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern void SetDIByte(byte[] commandBytes);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)] //get file list
		public static extern int GetDIList(IntPtr byteArray, ref int _size);
		[DllImport("PNFPenLib.dll", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
		public static extern int DIOpenFileStop();
		
		
		public static int EquilModelCode = 2;
		public static int CURRENT_MARKER_DIRECT;
	}
	
}
