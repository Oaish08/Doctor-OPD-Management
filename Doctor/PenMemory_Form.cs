using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class PenMemory_Form : Form
    {
        Dictionary<string, List<int>> DI_dataList;

        int nYear = 0;
        int nMonth = 0;
        int nDay = 0;
        int nHour = 0;
        int nMin = 0;
        int nSec = 0;
        public PenMemory_Form()
        {
            InitializeComponent();
            DI_dataList = new Dictionary<string, List<int>>();
            AlertMessages("Please wait while connecting the Pen");
            timer_toclose.Start();
        }

        #region Offline Data

        public void SetDIList_offlineMemory()
        {
            byte[] clist = null;
            try
            {
                int _size = 0;
                Module1.GetDIList((IntPtr)null, ref _size);

                clist = (byte[])Array.CreateInstance(typeof(Byte), _size);

                GCHandle pData = GCHandle.Alloc(clist, GCHandleType.Pinned);
                Module1.GetDIList(pData.AddrOfPinnedObject(), ref _size);
                pData.Free();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetDilist error - " + ex.Message);
            }

            MakeImportNotebookList(clist);
        }

        private void MakeImportNotebookList(byte[] importList)
        {
            //yy/MM/dd/hh/mm/ss/size - 6byte + 4byte(int)
            int nOffset = 0;
            int nTotalSize = importList.Length;
            byte[] tmp = new byte[10];
            string newFolder = "StartFolder";
            string oldFolder = string.Empty;

            DI_dataList.Clear();
            int folderIdx = -1;
            int fileIdx = 0;

            int nYearOld = 0;
            int nMonthOld = 0;
            int nDayOld = 0;

            while (nTotalSize > 0)
            {
                Buffer.BlockCopy(importList, nOffset, tmp, 0, 10); //copy 10byte
                int nSize = BitConverter.ToInt32(tmp, 6);
                nYear = Convert.ToInt32(tmp[0]);
                nMonth = Convert.ToInt32(tmp[1]);
                nDay = Convert.ToInt32(tmp[2]);
                nHour = Convert.ToInt32(tmp[3]);
                nMin = Convert.ToInt32(tmp[4]);
                nSec = Convert.ToInt32(tmp[5]);

                //Debug.WriteLine("{0}{1}{2}{3}{4}{5}{6}", nYear, nMonth, nDay, nHour, nMin, nSec, nSize);
                string sfileName = string.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}_{6}", nYear + 2000, nMonth, nDay, nHour, nMin, nSec, nSize);
                if (nYear == nYearOld & nMonth == nMonthOld & nDay == nDayOld)
                {
                    fileIdx++;
                }
                else
                {
                    folderIdx++;
                    fileIdx = 0;
                }
                Console.WriteLine("sfileName=" + sfileName);
                nOffset += 10; //move offset
                nTotalSize -= 10;

                listBox1.Items.Add(sfileName);
                //offline_DataList.Add(sfileName);
                List<int> ll = new List<int>();
                ll.Add(folderIdx);
                ll.Add(fileIdx);
                DI_dataList.Add(sfileName, ll);
                nYearOld = nYear;
                nMonthOld = nMonth;
                nDayOld = nDay;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            download_OfflineData(listBox1.SelectedItem.ToString());
        }

        public void download_OfflineData(string fileName)
        {
            List<int> ll = DI_dataList[fileName];
            Module1.SetDI((int)Module1.DICOMMAND.OPENFILE, ll[0], ll[1]);
        }

        public void SetDIList()
        {
            this.SetDIList_offlineMemory();
        }

        #endregion

        public void AlertMessages(string message)
        {
            lbmessage.Text = message;
        }

        private void timer_toclose_Tick(object sender, EventArgs e)
        {
            this.Close();
            timer_toclose.Stop();
        }
    }
}
