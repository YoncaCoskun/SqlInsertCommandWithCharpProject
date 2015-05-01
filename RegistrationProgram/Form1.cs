using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("server=.;database=Records;integrated security=sspi;");

        private void dataShow()
        {
            connect.Open();

            SqlCommand command = new SqlCommand("select * from tblPersonels", connect);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                ListViewItem row = new ListViewItem(reader["Name"].ToString());
                row.SubItems.Add(reader["Surname"].ToString());
                row.SubItems.Add(reader["Business"].ToString());

                listView1.Items.Add(row);

            }

            connect.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataShow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connect.Open();

            SqlCommand command = new SqlCommand("insert into tblPersonels(Name,Surname,Business) values('"+txtName.Text+"','"+txtSurname.Text+"','"+txtBusiness.Text+"')",connect);
            command.ExecuteNonQuery();          
            connect.Close();
            dataShow();

            button1.Enabled = false;
        }

       
    }
}
