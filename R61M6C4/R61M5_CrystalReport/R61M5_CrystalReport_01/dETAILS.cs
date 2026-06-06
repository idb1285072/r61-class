using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace R61M5_CrystalReport_01
{
    public partial class dETAILS : Form
    {
        public dETAILS()
        {
            InitializeComponent();
        }
        private void LoadReport()
        {
            string con = ConfigurationManager.ConnectionStrings["TaskContext"].ConnectionString;
            string sql = "TaskDetails";
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connection);
                sqlDataAdapter.Fill(dataSet);

                // Debug: Check the number of rows
                // MessageBox.Show(dataSet.Tables[0].Rows.Count.ToString());
            }

            string rootd = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string reportPath = Path.Combine(rootd, "rptDetails.rpt");

            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(reportPath);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                reportDocument.SetDataSource(dataSet.Tables[0]);
                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("No records to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dETAILS_Load(object sender, EventArgs e)
        {
            LoadReport();   

        }
    }
}
