using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;

namespace Accounting
{
    public partial class frm_AddCustomer : Form
    {
        public int CustomerID = 0;
        public frm_AddCustomer()
        {
            InitializeComponent();
            
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pc.ImageLocation = openFileDialog.FileName;
            }
        }

        private void btninsertdata_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                string locationName = string.Empty;
                if (pc.Image != null)
                {
                    locationName = Guid.NewGuid().ToString() + Path.GetExtension(pc.ImageLocation);
                    if (!Directory.Exists(Application.StartupPath + "/Images/"))
                    {
                        Directory.CreateDirectory(Application.StartupPath + "/Images/");
                    }
                    pc.Image.Save(Application.StartupPath + "/Images/" + locationName);
                }
                
                using (Business.Customers UOW = new Business.Customers())
                {
                    DataLayer.Customers customer = new DataLayer.Customers()
                    {
                        
                        Address = txtAddress.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        FullName = txtName.Text.Trim(),
                        Mobile = txtMobile.Text.Trim(),
                        Image = locationName
                    };
                    if (CustomerID != 0)
                    {
                        customer.ID = CustomerID;
                        UOW.Update(customer);
                    }
                    else
                    {
                        UOW.Insert(customer);
                    }
                    
                    UOW.Save();
                }
            }
        }

        private void frm_AddCustomer_Load(object sender, EventArgs e)
        {
            if (this.CustomerID != 0)
            {
                this.Text = "ویرایش";
                btninsertdata.Text = "ویرایش";
                using (Business.Customers UOW = new  Business.Customers())
                {
                    var sel = UOW.Get(w => w.ID == CustomerID).FirstOrDefault();
                    txtAddress.Text = sel.Address;
                    txtEmail.Text = sel.Email;
                    txtMobile.Text = sel.Mobile;
                    txtName.Text = sel.FullName;
                    pc.ImageLocation = Application.StartupPath + "/Image/" + sel.Image;
                }
            }
        }
    }
}
