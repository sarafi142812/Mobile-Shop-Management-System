﻿using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace MobileShopMangementSystem.AllUserControl
{
    public partial class UC_Stock : UserControl
    {
        function fn = new function();
        String query;
        public UC_Stock()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void UC_Stock_Enter(object sender, EventArgs e)
        {
            query = "SELECT * FROM newMobile";
            var dataTable = fn.GetData(query).Tables[0];
            guna2DataGridView1.DataSource = dataTable;
        }

        int bid;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < guna2DataGridView1.Rows.Count)
            {
                if (guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value != null &&
                    !string.IsNullOrEmpty(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    if (int.TryParse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), out bid))
                    {
                        query = "select * from newMobile where mid = " + bid;
                        DataSet ds = fn.GetData(query);

                        companylabel.Text = ds.Tables[0].Rows[0][1].ToString();
                        modellabel.Text = ds.Tables[0].Rows[0][2].ToString();
                        ramlabel.Text = ds.Tables[0].Rows[0][3].ToString();
                        internallabel.Text = ds.Tables[0].Rows[0][4].ToString();
                        expandablelabel.Text = ds.Tables[0].Rows[0][5].ToString();
                        displaylabel.Text = ds.Tables[0].Rows[0][6].ToString();
                        rearlabel.Text = ds.Tables[0].Rows[0][7].ToString();
                        frontlabel.Text = ds.Tables[0].Rows[0][8].ToString();
                        fingerlabel.Text = ds.Tables[0].Rows[0][9].ToString();
                        simlabel.Text = ds.Tables[0].Rows[0][10].ToString();
                        networklabel.Text = ds.Tables[0].Rows[0][11].ToString();
                        pricelabel.Text = ds.Tables[0].Rows[0][12].ToString();
                    }
                    else
                    {
        
                        MessageBox.Show("Invalid value in the selected cell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
