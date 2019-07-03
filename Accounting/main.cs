using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Accounting
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frm_Customers frm_Customers = new frm_Customers();
            frm_Customers.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {
            //List<string> names = new List<string>();
            //names.Add("shokoofe");
            //names.Add("javad");
            //names.Add("ali");
            //names.Add("hamid");
            //var sel = (from n in names select n);

            //names.Add("jafar........");

            //string namess = "";
            //foreach (var item in sel)
            //{
            //    namess += item;
            //}
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmNewTransaction frmNewTransaction = new frmNewTransaction();
            frmNewTransaction.ShowDialog();
        }
    }
}
