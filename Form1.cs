using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chart1
{
    public partial class Form1 : Form
    {
        private CPUTILLib.CpStockCode cpstkcode; //멤버선언
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cpstkcode = new CPUTILLib.CpStockCode(); //인스턴스 생성
        }
    }
}
