using Accounting.DataLayer.Context;
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
    public partial class frmNewTransaction : Form
    {
        Business.Accounting accounting;
        public frmNewTransaction()
        {
            accounting = new Business.Accounting();
            InitializeComponent();
        }

        private void frmNewTransaction_Load(object sender, EventArgs e)
        {
            
                try
                {
                    dgvNames.AutoGenerateColumns = false;
                    dgvNames.DataSource = accounting.Get();// uow.Accounting.Get();
                }
                catch (Exception w)
                {

                    throw;
                }
            
        }
    }
}
