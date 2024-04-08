using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using DataAccessLayer;
using DataLibrary.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseControllercs
    {
       // SQLDB DataAcces;
        //private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env) : base(configuration)
        {
           /* _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("EmployeeAppCon");
            DataAcces = new SQLDB(connectionString);
            _env = env; */
            
        }


        [HttpGet]
        public JsonResult Get()
        {
            /*   
               string query = @"
                               select EmployeeId, EmployeeName,Department,
                               convert(varchar(10),DateOfJoining,120) as DateOfJoining,PhotoFileName
                               from
                               dbo.Employee
                               ";

               DataTable table = new DataTable();
               string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
               SqlDataReader myReader;
               using (SqlConnection myCon = new SqlConnection(sqlDataSource))
               {
                   myCon.Open();
                   using (SqlCommand myCommand = new SqlCommand(query, myCon))
                   {
                       myReader = myCommand.ExecuteReader();
                       table.Load(myReader);
                       myReader.Close();
                       myCon.Close();
                   }
               } */

            DataTable table = DataAcces.GetEmlployee();
            return new JsonResult(table);
        }

        [HttpPost]
        public Response Employee(Employee emp)
        {
           
            Response response = new Response();
            
            bool ret = DataAcces.PostEmlployee(emp);

            if (ret)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Insert Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Insert Failed!";
            }
            return response;

        }


        [HttpPut]
        public Response Put(Employee emp)
        {
            /*
            string query = @"
                           update dbo.Employee
                           set EmployeeName= @EmployeeName,
                            Department=@Department,
                            DateOfJoining=@DateOfJoining,
                            PhotoFileName=@PhotoFileName
                            where EmployeeId=@EmployeeId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", emp.Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", emp.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }*/
            //DataTable table = DataAcces.PutEmlployee();

            //return new JsonResult("Updated Successfully");
            Response response = new Response();

            bool ret = DataAcces.PutEmployee(emp);

            if (ret)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Update Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Update Failed!";
            }
            return response;


        }

        [HttpDelete("{id}")]
        public Response Delete(Employee EmployeeId)
        {
            /*
            string query = @"
                           delete from dbo.Employee
                            where EmployeeId=@EmployeeId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            } */
            // DataTable table = DataAcces.DeleteEmlployee();

            //return new JsonResult("Deleted Successfully");
            Response response = new Response();

            bool ret = DataAcces.DeleteEmployee(EmployeeId);

            if (ret)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Delete Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Delete Failed!";
            }
            return response;
        }

        //For the image
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }
    }
}
