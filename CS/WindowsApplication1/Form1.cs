using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;
using DevExpress.Utils.Controls;
using DevExpress.Utils;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        Color GetRandomColor()
        {
            return Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                Form form = new Form();
                form.MdiParent = this;
                form.Show();
                form.Text = String.Format("Page{0}", i);
                form.BackColor = GetRandomColor();
            }
        }
    }
}