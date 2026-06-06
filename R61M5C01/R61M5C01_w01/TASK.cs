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
using R61M5C01_w01.Models;

namespace R61M5C01_w01
{
    public partial class TASK : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        //SqlDataAdapter adapter;
        public TASK()
        {
            InitializeComponent();
           // MessageBox.Show("constructor");
        }

        private void TASK_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("load");
            loadTask();
        }

        private void loadTask()
        { 
            List<EmpTask> empTasks = new List<EmpTask>();
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            string sql = $"select * from Task ";
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EmpTask empTask = new EmpTask();
                    empTask.Name = reader["Name"].ToString();
                    empTask.Description = reader["Description"].ToString();
                    empTask.Id = int.Parse(reader["Id"].ToString());
                    empTasks.Add(empTask);
                }
            }
            dataGridView2.DataSource = empTasks;
            con.Close();
        }
    }
}
