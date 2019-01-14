using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Personel
{
    public partial class MarsForm : Form
    {
        SqlConnection con;
        string constr = "Data Source=SEM-BILGISAYAR;Initial Catalog=NORTHWND2;User ID=test;Password=test;MultipleActiveResultSets=True";
        public MarsForm()
        {
            InitializeComponent();
        }

        private void MarsForm_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select distinct country from Customers ", con);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string country = rdr["country"].ToString();
                TreeNode node = new TreeNode(country);
                treeView1.Nodes.Add(node);

                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandText = "Select CompanyName from Customers  Where country=@country";
                cmd2.Parameters.AddWithValue("@country", country);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    string customer = rdr2["CompanyName"].ToString();
                    TreeNode customernode = new TreeNode(customer);
                    node.Nodes.Add(customernode);
                }
                     
            }
            con.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // MessageBox.Show();
        }
    }
}
