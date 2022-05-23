using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OJTProject.Dal;
using System.Threading;

namespace OJTProject
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        bool loadingIsAlreadyShowing = false;
        private void ShowLoading(string message)
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }

                if (!loadingIsAlreadyShowing)
                {
                    loadingIsAlreadyShowing = true;
                    splashScreenManager1.ShowWaitForm();
                }
                splashScreenManager1.SetWaitFormDescription(message);
            }
            catch { }
        }

        private void HideLoading()
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = true;
                }

                loadingIsAlreadyShowing = false;
                splashScreenManager1.CloseWaitForm();
            }
            catch { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //login begins here:
            if(!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            //if (txtUsername.Text != "" && txtPassword.Text == "")
            {
                ShowLoading("Authentication...");
                bwLogin.RunWorkerAsync();
            }
            else
                MessageBox.Show("Cannot proceed without username or password!");
        }

        DataTable data = new DataTable();
        private void bwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            data = Users.Login(txtUsername.Text, txtPassword.Text);
            bwLogin.CancelAsync();
        }

        private void bwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (data.Rows.Count > 0)
            {
                //MessageBox.Show("OK");
                this.Hide();

                CRUD c = new CRUD();
                c.ShowDialog();

                this.Close();
            }
            else
                MessageBox.Show("INVALID USERNAME AND/OR PASSWORD");
        }
    }
}
