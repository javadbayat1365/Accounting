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
    public partial class frm_Customers : Form
    {
        public frm_Customers()
        {
            InitializeComponent();
        }

        private void frm_Customers_Load(object sender, EventArgs e)
        {
            dgvcustomers.AutoGenerateColumns = false;
            DataBinding();
        }

        private void DataBinding()
        {
            using (UnitOfWork UOF = new UnitOfWork())
            {
                dgvcustomers.DataSource = UOF.Customers.GetAll();

            }
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
