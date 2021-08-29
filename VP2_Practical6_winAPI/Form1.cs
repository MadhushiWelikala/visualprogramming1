using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace VP2_Practical6_winAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        [DllImport("User32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        [DllImport("kernel32")] 
        static extern void GetSystemInfo(ref SYSTEM_INFO pSI);


        protected void button1_Click_1(object sender, System.EventArgs e)
        {
            // MessageBox(0, "API Message Box", "API Demo", 0);

            try
            {
                SYSTEM_INFO pSI = new SYSTEM_INFO();
                GetSystemInfo(ref pSI); //Once you retrieve the structure, perform operations on the required parameter e.g.listBox1.InsertItem (0,pSI.dwActiveProcessorMask.ToString());
                MessageBox(0, pSI.lpMinimumApplicationAddress.ToString(), "API Demo", 0);
            }
            catch (Exception er)
            {
                MessageBox(0, er.Message, "API Demo", 0);
            }

        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        public uint dwOemId;
        public uint dwPageSize;
        public uint lpMinimumApplicationAddress;
        public uint lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        public uint dwProcessorLevel;
        public uint dwProcessorRevision;
    }

}
