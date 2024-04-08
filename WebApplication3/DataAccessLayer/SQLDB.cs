using System.Data;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Hosting;
using DataLibrary.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;






//using WebApplication3.Models;


namespace DataAccessLayer
{
    public class SQLDB :Data

    {
        SqlConnection connection;
        

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private string connectionstring; 


        public SQLDB()
        {
        }
        
        /*
        public SQLDB(string connectionstring)
        {
            this.connectionstring = connectionstring;
        } */
        
        public SQLDB(string connectionString)
        {
            base.ConnectionString = connectionString;
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

        }  
        /*
        public SQLDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SQLDB(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            
        } */

        public override DataTable GetDeparment()
        {
            string query = @"select DepartmentId, DepartmentName from  dbo.Department";

            DataTable table = new DataTable();
           
            SqlDataReader myReader;
           
                connection.Open();
                
                using (SqlCommand myCommand = new SqlCommand(query,connection))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connection.Close();
                }
           
           

            return table;
        }
       
        //work file

        /*
            public override bool PostDepartment(Department dep)
            {
            /*

            string query = @"
                           insert into dbo.Department
                           values (@DepartmentName)
                            ";

            DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            string sqlDataSource = connectionstring;
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            } 
            //string sqlDataSource = connectionstring;
           // SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))

                SqlCommand cmd = new SqlCommand("INSERT INTO Department(DepartmentName) VALUES ('" + dep.DepartmentName + "')",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
           

            if (i > 0)
                return true;
            return false;


          
        } */
        /*

            public override bool Registration(Registration registration)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Registration(Name,Email,Password,Phone,IsActive,IsApproved,AccountType) VALUES ('" + registration.Name + "','" + registration.Email + "','" + registration.Password + "','" + registration.Phone + "',1,0, '" + registration.AccountType + "')", connection);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    return true;
                return false;
            }
        }
    }
*/

        //new try

    public override bool  PostDepartment(Department dep)
        {
           

            string query = @"insert into dbo.Department values (@Department)";

            DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //string sqlDataSource = connectionstring;
            //SqlDataReader myReader;
           // using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
                connection.Open();
                using (SqlCommand cmd= new SqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@Department",dep.DepartmentName);
                    //myReader = cmd.ExecuteReader();
                   // table.Load(myReader);
                   // myReader.Close();
                    //myCon.Close();
                    //connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();


                    if (i > 0)
                        return true;
                    return false;
                }
            }

            

            
        

       

        public override bool PutDepartment(Department dep)
        {
            

            string query = "update dbo.Department set DepartmentName='"+ dep.DepartmentName+"' where DepartmentId="+dep.DepartmentId ;

            DataTable table = new DataTable();
            //string sqlDataSource = connectionstring;
            //SqlDataReader myReader;
            // using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                 //cmd.Parameters.AddWithValue("@DepartmentId",Department.DepartmentId);
                //cmd.Parameters.AddWithValue("@DepartmentName", dep);
                  // myReader = cmd.ExecuteReader();
                    //table.Load(myReader);
                   // myReader.Close();
                
                int i = cmd.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                    return true;
                return false;
            }
            //}
            

            //return table;
           /*
            
            SqlCommand cmd = new SqlCommand("Update Department(DepartmentName) set ('" + DepartmentName.DepartmentName + "' )", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();*/
            



        }
       

        public override bool DeleteDepartment(Department DepartmentId)
        {
            string sqlCmd = "Delete Department where DepartmentId='" + DepartmentId.DepartmentId + "'";
            SqlCommand cmd = new SqlCommand(sqlCmd, connection);
            //SqlCommand cmd = new SqlCommand("Delete Department where DepartmentId='" + DepartmentId.DepartmentId + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            

            if (i > 0)
                return true;
            return false;

        }

       


        public override DataTable  GetEmlployee()
        {
            string query = @"select EmployeeId, EmployeeName,Department,convert(varchar(10),DateOfJoining,120) as DateOfJoining,PhotoFileName from dbo.Employee";

            DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //string sqlDataSource = connectionstring;
         
            //connection.Open();
            SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(connection))
            //{
            connection.Open();
                using (SqlCommand myCommand = new SqlCommand(query,connection))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                connection.Close();
                }
            //}
            return table;
        }

        // public DataTable PostEmlployee(string EmployeeName,string Department,string DateOfJoining,string PhotoFileName)
        public override bool PostEmlployee(Employee emp)
        {
            

            SqlCommand cmd = new SqlCommand("INSERT INTO Employee(EmployeeName,Department,DateOfJoining,PhotoFileName) VALUES ('" + emp.EmployeeName + "','" + emp.Department + "','" + emp.DateOfJoining + "','" + emp.PhotoFileName +"')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();


            if (i > 0)
                return true;
            return false;

        }




        //public DataTable PutEmlployee(int EmployeeId,string EmployeeName, string Department, string DateOfJoining, string PhotoFileName)
       public override bool PutEmployee(Employee emp)
        {
            //string query = "update dbo.Employee  SET (EmployeeName,Department,DateOfJoining,PhotoFileName) Values ('" + emp.EmployeeName + "','" + emp.Department + "', '" + emp.DateOfJoining + "', '" + emp.PhotoFileName + "' )where EmployeeId=" + emp.EmployeeId;
            string query = "update dbo.Employee  SET EmployeeName='" + emp.EmployeeName+ "'where EmployeeId="+emp.EmployeeId;
           // SqlCommand cmd = new SqlCommand("UPDATE Employee(EmployeeName,Department,DateOfJoining,PhotoFileName) VALUES ('" + emp.EmployeeName + "','" + emp.Department + "','" + emp.DateOfJoining + "','" + emp.PhotoFileName + "')where EmployeeId=" + emp.EmployeeId, connection);
            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //string sqlDataSource = connectionstring;
            //SqlDataReader myReader;
            //using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
            connection.Open();
                using (SqlCommand cmd = new SqlCommand(query,connection))
                {
                    /*
                    myCommand.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", Department);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", PhotoFileName); */
                    //myReader = myCommand.ExecuteReader();
                    //table.Load(myReader);
                    //myReader.Close();

                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                    return true;
                return false;
           
            }


           
        }



        //public DataTable DeleteEmlployee(int id)
        public override bool DeleteEmployee(Employee EmployeeId)
        {
            string query = "DELETE from dbo.Employee where EmployeeId=" + EmployeeId.EmployeeId;

            DataTable table = new DataTable();
            // sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            //string sqlDataSource = connectionstring;

           // SqlDataReader myReader;
           // using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            //{
               connection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, connection))
                {
                    //myCommand.Parameters.AddWithValue("@EmployeeId",emp.EmployeeId);

                    //myReader = myCommand.ExecuteReader();
                    //table.Load(myReader);
                    //myReader.Close();
                int i = myCommand.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                    return true;
                return false;
            }
            //}


            //return table;
        }

        public DataTable DeleteEmlployee()
        {
            throw new NotImplementedException();
        }

       
    }
}