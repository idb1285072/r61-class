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
using System.Xml.Linq;
using R61M5C01_w01.Models;

namespace R61M5C01_w01
{
    public partial class AssignTask : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        public AssignTask()
        {
            InitializeComponent();
        }

        private void AssignTask_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbTaskDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.dbTaskDataSet.Employee);
            this.LoadTask();
            LoadAssignedTask();
        }
        private void LoadAssignedTask()
        {
            
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            string sql = $"EmployeeAssignment ";
            con = new SqlConnection(connectionString);
            con.Open();
            //cmd = new SqlCommand(sql, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //reader = cmd.ExecuteReader();
            
            adapter = new SqlDataAdapter(sql, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
           dataGridView1.DataSource= dataTable;

        }
        private void LoadTask()
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
            cmbTask.DataSource = empTasks;
            cmbTask.DisplayMember = "Name";
            cmbTask.ValueMember = "Id";
            
            con.Close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            string sql = "";
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            //if (int.Parse(this.lblId.Text) > 0)
            //{
            //    sql = $"update  Employee set EmployeeName='{txtName.Text}',Designation='{txtDesignation.Text}',JoiningDate='{DateTime.Parse(DTPJD.Text)}',Salary={txtSalary.Text} where Id={lblId.Text}";
            //}
            //else
            //{
                sql = $"Insert into TaskAssign(EmpId,TaskId,AssignDate)values({cmbEmp.SelectedValue}," +
                            $"{cmbTask.SelectedValue},'{DateTime.Parse(dateTimePicker1.Text)}')";
            //}

            con = new SqlConnection(connectionString);
            cmd = new SqlCommand(sql, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Save Success");
                LoadAssignedTask();
                //loadEmployee();
                //ClearControl();
            }
            con.Close();
        }
    }
}
