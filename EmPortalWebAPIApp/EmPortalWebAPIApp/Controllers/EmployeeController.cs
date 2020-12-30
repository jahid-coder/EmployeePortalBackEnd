using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel;
using EmPortalWebAPIApp.Models;

namespace EmPortalWebAPIApp.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"SELECT employee_id,employee_name,department,mail_id,Convert (varchar(10),doj,120 ) AS DOJ FROM dbo.Employees";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppBD"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public string Post(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"
                    INSERT INTO dbo.Employees
                        (employee_name,
                         department,
                         mail_id,
                        doj)
                     Values(
                        '" + emp.EmployeeName + @"'
                        ,'" + emp.Department + @"'
                        ,'" + emp.MailID + @"'
                        ,'" + emp.DOJ + @"'
                        )";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppBD"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception  Ex )
            {
                return "Failed to Add";
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"
                   UPDATE dbo.Employees SET
                        employee_name = '" + emp.EmployeeName + @"'
                        ,department = '" + emp.Department + @"'
                        ,mail_id = '" + emp.MailID + @"'
                        ,doj = '" + emp.DOJ + @"'
                    WHERE employee_id = '" + emp.EmployeeID + @"'
                    ";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppBD"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception Ex)
            {
                return " Failed to Update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"
                   DELETE FROM dbo.Employees WHERE employee_id = " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppBD"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception Ex)
            {
                return " Failed to Delete";
            }
        }
    }
}
