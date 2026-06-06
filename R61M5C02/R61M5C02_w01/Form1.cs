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
using R61M5C02_w01.Models;

namespace R61M5C02_w01
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
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
            dataGridView1.DataSource = dataTable;

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
            cmbtask.DataSource = empTasks;
            cmbtask.DisplayMember = "Name";
            cmbtask.ValueMember = "Id";

            con.Close();
        }
        private void LoadEmployee()
        {
            List<Employee> emps = new List<Employee>();
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            string sql = $"select * from Employee order by EmployeeName asc ";
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee emp  = new Employee();
                    emp.Name = reader["EmployeeName"].ToString();
                    emp.Designation = reader["Designation"].ToString();
                    emp.Salary = double.Parse( reader["Salary"].ToString());
                    emp.Id = int.Parse(reader["Id"].ToString());
                    emps.Add(emp);
                }
            }
            cmbemployee.DataSource = emps;
            cmbemployee.DisplayMember = "EmployeeName";
            cmbemployee.ValueMember = "Id";
            con.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTask();
            LoadEmployee();

        }
      

        private void btnsave_Click(object sender, EventArgs e)
        {
   
          string  sql = $"Insert into TaskAssign(EmpId,TaskId,AssignDate)values({cmbemployee.SelectedValue}," +
                       $"{cmbtask.SelectedValue},'{DateTime.Parse(dateTimePicker1.Text)}')";
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            con = new SqlConnection(connectionString);
            con.Open();
            using (SqlTransaction transaction = con.BeginTransaction())
            {
                try
                {
                    cmd = new SqlCommand(sql,  con);
                    cmd.Transaction = transaction;
                    int result = cmd.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        //string sq = "select top 1 Id from TaskAssign order by Id desc";
                        string sq = "select @@Identity";
                        var cmd1 = new SqlCommand(sq, con);
                        cmd1.Transaction = transaction;
                        var assid = cmd1.ExecuteScalar();
                        string sqlstatus = $"Insert Into TaskStatus (AssignID,TaskStatus)" +
                                        $"  values({assid},'pending')";
                       var cmd2 = new SqlCommand(sqlstatus, con);
                        cmd2.Transaction = transaction;
                        int output = cmd2.ExecuteNonQuery();
                        if (output > 0)
                        {
                            MessageBox.Show("success");
                        }
                        //LoadAssignedTask();

                        //ClearControl();
                    }
                    
                    transaction.Commit();
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }

        }
    }
}
