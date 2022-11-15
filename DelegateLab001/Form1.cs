using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DelegateLab001
{
    public delegate void myDelegate();
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private void PrintInlabelPrintFile()
        {
            Finde finde = new Finde();
            labelPrintFile.Text = finde.FindeEmail();
        }
        private void buttonShowResult_MouseClick(object sender, MouseEventArgs e)
        {
            myDelegate _myDelegate = PrintInlabelPrintFile;
            _myDelegate();
        }
    }
}
