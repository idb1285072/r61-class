using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_17_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.Run();
            Console.WriteLine();
            using (TestClassD obj = new TestClassD())
            {
                obj.Run();

            }
            Console.WriteLine();
            using (SqlConnection con=new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Northwind;Trusted_Connection=True"))
            {
                con.Open();

                using(SqlCommand cmd = new SqlCommand("SELECT top 3 * FROM Customers", con))
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(dr.GetString(0));
                    }
                }
            }
            
            Console.ReadLine();
        }
    }
    public class TestClass
    {
        SqlConnection con;
        public TestClass()
        {
            con = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Northwind;Trusted_Connection=True");
        }
        public void Run()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT top 3 * FROM Customers", con);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr.GetString(0));
            }
            con.Close();
        }
        ~TestClass()
        {

            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

        }
    }
    public class TestClassD : IDisposable
    {
        SqlConnection con;
        public TestClassD()
        {
            con = new SqlConnection(@"Data Source=.\SQLExpress;Initial Catalog=Northwind;Trusted_Connection=True");
        }

        

        public void Run()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 3" +
                " * FROM Customers", con);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr.GetString(0));
            }
            con.Close();
        }
        public void Dispose()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
