using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DataAccessLayer;
using DataLibrary;
using DataLibrary.Models;
//using Swashbuckle.Swagger;
//using SQLDB;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //public class DepartmentController : ControllerBase
    public class DepartmentController : BaseControllercs
    {
        //SQLDB DataAcces;
        //private readonly IConfiguration _configuration;

        /*
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("EmployeeAppCon");
            DataAcces = new SQLDB(connectionString);
        }*/
        public DepartmentController(IConfiguration configuration) : base(configuration)
        {
            //DataAcces = new SQLDB(connectionString)
        }

        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = DataAcces.GetDeparment();
           
           


            return new JsonResult(table);
        }

        [HttpPost]
     
        public Response PostDepartment(Department DepartmentName)
        {
            Response response = new Response();
            
                bool ret = DataAcces.PostDepartment(DepartmentName);

            if (ret)
            {
                response.StatusCode= 200;
                response.StatusMessage = "Registration Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration Failed!";
            }
            return response;
        }

        [HttpPut]
        public Response PutDepartment( Department DepartmentName)
        {
            
            Response response = new Response();
            
            bool ret = DataAcces.PutDepartment(DepartmentName);

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
        public Response DeleteDepartment(Department DepartmentId)
        {
            
            Response response = new Response();
            
            bool ret = DataAcces.DeleteDepartment(DepartmentId);

            if (ret)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Deleted Successful!";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Deleted Failed!";
            }
            return response;
        }
    }


    
}

