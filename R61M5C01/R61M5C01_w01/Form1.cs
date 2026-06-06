using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R61M5C01_w01
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        //SqlDataReader reader;
        SqlDataAdapter adapter;
        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            if(int.Parse( this.lblId.Text)>0)
            {
                sql = $"update  Employee set EmployeeName='{txtName.Text}',Designation='{txtDesignation.Text}',JoiningDate='{DateTime.Parse(DTPJD.Text)}',Salary={txtSalary.Text} where Id={lblId.Text}";
            }
            else
            {
                sql = $"Insert into Employee(EmployeeName,Designation,JoiningDate,Salary)values('{txtName.Text}'," +
                            $"'{txtDesignation.Text}','{DateTime.Parse(DTPJD.Text)}',{txtSalary.Text}      )";
            }
              
           con = new SqlConnection(connectionString);
            cmd=new SqlCommand(sql,con);
            con.Open();
            int  result= cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Save Success");
                loadEmployee();
                ClearControl();
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadEmployee();
        }

        private void loadEmployee()
        {
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            string sql = $"select * from Employee ";
            con = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(sql,con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = dataGridView1.SelectedRows;
            this.txtName.Text = selectedItem[0].Cells[1].Value.ToString();
            this.txtDesignation.Text = selectedItem[0].Cells[2].Value.ToString();
            this.txtSalary.Text = selectedItem[0].Cells[4].Value.ToString();
            this.DTPJD.Text = selectedItem[0].Cells[3].Value.ToString();
            this.lblId.Text = selectedItem[0].Cells[0].Value.ToString();
            this.btnSave.Text = "Update";
            this.btnDel.Enabled = true;
            this.btnClear.Enabled=true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void ClearControl()
        {
            this.txtName.Text = "";
            this.txtDesignation.Text = "";
            this.txtSalary.Text = "";
            this.DTPJD.Text = "";
            this.lblId.Text = "";
            this.btnSave.Text = "Save";
            this.btnDel.Enabled = false;
            this.btnClear.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string sql = "";
            string connectionString = "Data Source=DESKTOP-PNALNN3\\SQLEXPRESS;Initial catalog=dbTask;Trusted_Connection=true";
            if (int.Parse(this.lblId.Text) > 0)
            {
                sql = $"delete from  Employee where Id={int.Parse( lblId.Text)}";
            }
            con = new SqlConnection(connectionString);
            cmd = new SqlCommand(sql, con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Save Success");
                loadEmployee();
                ClearControl();
            }
            con.Close();
        }
    }
}
