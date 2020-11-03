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
        private CPUTILLib.CpCybos cpCybos;
        private CPUTILLib.CpStockCode cpstkcode; //멤버선언
        private CPSYSDIBLib.StockChart stkchart; //멤버선언

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cpCybos = null;
            cpCybos = new CPUTILLib.CpCybos();
            cpstkcode = new CPUTILLib.CpStockCode(); //인스턴스 생성
            stkchart = new CPSYSDIBLib.StockChart(); //인스턴스 생성
            
            if (cpCybos.IsConnect == 0)
            {
                return;
            }
            
            stkchart.Received += Stkchart_Received;
        }

        private void Stkchart_Received()
        {
            chart1.Series[0].Points.Clear();
            int cnt = stkchart.GetHeaderValue(3);  //수신개수

            for (int i = cnt-1; i >= 0; i--)
            {
                int open = stkchart.GetDataValue(1, i);
                int high = stkchart.GetDataValue(2, i);
                int low = stkchart.GetDataValue(3, i);
                int close = stkchart.GetDataValue(4, i);

                chart1.Series[0].Points.AddY(high,low,open,close);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                label1.Text = cpstkcode.NameToCode(textBox1.Text.Trim());

                stkchart.SetInputValue(0,label1.Text);  //종목코드

                stkchart.SetInputValue(1,'2');  //요청구분 '2' : 개수
                stkchart.SetInputValue(4,100);  //요청개수
                stkchart.SetInputValue(5,new int[] { 0, 2, 3, 4, 5 });//요청필드 {날짜, 시,고,저 종}
                stkchart.SetInputValue(6,'D');  //차트구분 'D' : 일

                stkchart.Request();

            }
        }
    }
}
