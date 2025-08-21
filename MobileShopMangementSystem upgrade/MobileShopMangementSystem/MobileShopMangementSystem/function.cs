using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopMangementSystem
{
    internal class function
    {
        protected SqlConnection GetSqlConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=RAFI\\SQLEXPRESS;Initial Catalog=Mobileshop;Integrated Security=True;Encrypt=False";
            return con;
        }

        public DataSet GetData(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = GetSqlConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public void SetData(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = GetSqlConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Processed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public SqlDataReader GetForCombo(string query, SqlParameter[] parameters = null)
        {
            SqlConnection con = GetSqlConnection();
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr;
            }
        }

        internal void CloseConnection()
        {
            // Implement the actual closing of the connection here
            // For example, if you have a SqlConnection instance, you can close it as follows:
            // SqlConnection con = GetSqlConnection();
            // con.Close();
        }
    }
}