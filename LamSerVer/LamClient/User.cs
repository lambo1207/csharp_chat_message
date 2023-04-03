using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamClient
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập tên!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ClientList.Username = txtName.Text;

            this.Hide();
            this.Close();
        }

        public String NameLogin()
        {
            return txtName.Text;
        }
    }
}
