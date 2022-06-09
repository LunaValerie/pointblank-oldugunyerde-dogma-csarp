using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace Tutorial
{
    public partial class LunaUI : Form
    {

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public static string CoordY = "PointBlank.exe+00F53A0C,5DC,160,14,124";

        public static string Healths = "PointBlank.exe+00F4A828,D04";

        public static string CoordX = "PointBlank.exe+00F4A824,B0,5DC,160,14,11C";

        public LunaUI()
        {
            InitializeComponent();
        }

        Mem mem = new Mem();

        private void LunaUI_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int PID = mem.GetProcIdFromName("PointBlank");
            if (PID >0)
            {
                mem.OpenProcess(PID);
                MessageBox.Show(PID.ToString());
            }
        }

        private void checkhealth_Tick(object sender, EventArgs e)
        {
            float healthvalue = mem.ReadFloat(Healths);
            textBox1.Text = healthvalue.ToString();
            flyhack.Start();
        }

        private void deathkonturol_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                checkhealth.Stop();
                deathkonturol.Stop();
                dogumkonturol.Start();
                flyhack.Stop();
            }
        }

        private void dogumkonturol_Tick(object sender, EventArgs e)
        {
            float healthvalue = mem.ReadFloat(Healths);
            textBox1.Text = healthvalue.ToString();
            mem.WriteMemory(CoordY, "float", textBox2.Text);
            flyhack.Start();
        }

        private void flyhack_Tick(object sender, EventArgs e)
        {
            float healthvalue2 = mem.ReadFloat(CoordX);
            textBox2.Text = healthvalue2.ToString();
        }
    }
}
