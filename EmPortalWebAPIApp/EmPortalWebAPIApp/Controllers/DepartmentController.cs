using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EmPortalWebAPIApp.Models;

namespace EmPortalWebAPIApp.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"SELECT department_id AS DepartmentID,department_name AS DepartmentName FROM dbo.departments";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppBD"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
              
        }
        public string Post(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"INSERT INTO dbo.departments Values('"+ dep.DepartmentName + @" ')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppBD"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                
                return "Added Successfully";
            }
            catch(Exception )
            {
                return " Failed to Add";
            }
        }
        public string Put(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"
                   UPDATE dbo.Departments SET department_name = '"+ dep.DepartmentName + @"'
                    WHERE department_id = '" + dep.DepartmentID + @"'
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
                   DELETE FROM dbo.Departments WHERE department_id = " +id;
                   
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
