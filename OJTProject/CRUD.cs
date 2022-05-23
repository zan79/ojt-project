using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OJTProject.Dal;
using OJTProject.Core;

namespace OJTProject
{
    public partial class CRUD : DevExpress.XtraEditors.XtraForm
    {
        public CRUD()
        {
            InitializeComponent();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            ViewData();
        }

        private void ViewData() 
        {
            //get data...
            DataTable data = Products.Get();
            dtData.DataSource = data;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewData();
        }

        private void ObjectControl(bool isAdding) 
        {
            dtData.Enabled = !isAdding;
            btnAdd.Enabled = !isAdding;
            btnEdit.Enabled = !isAdding;
            btnDelete.Enabled = !isAdding;
            btnRefresh.Enabled = !isAdding;

            gbDetails.Enabled = isAdding;
        }

        bool isAdding = false;  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAdding = true;
            EmptyInputs();
            ObjectControl(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ObjectControl(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ObjectControl(true);
        }

        private void gvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try 
            {
                if (gvData.SelectedRowsCount > 0)
                {
                    txtCode.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "code").ToString();
                    txtName.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, "name").ToString();
                }
                else 
                    EmptyInputs();
            }
            catch
            {
                EmptyInputs();
            }
        }

        private void EmptyInputs()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdding) 
            {
                Products.Add(txtCode.Text, txtName.Text);
                MsgBox.Information("Successfully added!");
            }
            else 
            {
                int selectedId = Convert.ToInt32(gvData.GetRowCellValue(gvData.FocusedRowHandle, "id"));
                Products.EditProducts(txtCode.Text, txtName.Text, selectedId);
                //MessageBox.Show("Successfully saved!");
                MsgBox.Information("Successfully saved!");
            }

            ViewData();
            ObjectControl(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvData.SelectedRowsCount > 0) 
            {
                string selectedProductName = gvData.GetRowCellValue(gvData.FocusedRowHandle, "name").ToString();
                //bool isYes = MessageBox.Show("Are you sure you want to delete [" + selectedProductName + "]?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                MsgBox.QuestionWarning("Are you sure you want to delete [" + selectedProductName + "]?");
                //if (isYes)
                if(MsgBox.IsYes)
                {
                    int selectedId = Convert.ToInt32(gvData.GetRowCellValue(gvData.FocusedRowHandle, "id"));
                    Products.Delete(selectedId);
                    MsgBox.Information("Successfully deleted!");

                    ViewData();
                    ObjectControl(false);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}