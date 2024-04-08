using System;
using DataLibrary;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLibrary.Models;

namespace DataAccessLayer
{

    public class XML : Data
    {
        string xmlFileName = "..\\..\\XMLD.xml";
        string connectionString = String.Empty;

        public XML()
        {

        }
        public XML(string connectionString)
        {
            this.xmlFileName = connectionString;
        }

        

        public override DataTable GetDeparment()
        {
            
            DataTable dt = new DataTable();
            DataSet dataSet = new DataSet();
            if (File.Exists(xmlFileName))
            {
                dataSet.ReadXml(xmlFileName, XmlReadMode.InferSchema);
                if (dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables["Department"];

                }
            }

            return dt;
        }

       

        public override bool PostDepartment(Department departmentName)
        {
            bool result = false;

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFileName);
                int lastID = 0;
                if (dataSet.Tables["Department"].Rows.Count > 0)
                {
                    //lastID = Convert.ToInt32(dataSet.Tables["Department"].Rows[dataSet.Tables["Department"].Rows.Count - 1]);
                    lastID = dataSet.Tables["Department"].Rows.Count ;
                }

                DataRow newRow = dataSet.Tables["Department"].NewRow();
                newRow["DepartmentId"] = lastID + 1; // Set the new ID to the last ID + 1
                newRow["DepartmentName"] = departmentName.DepartmentName;
               

                dataSet.Tables["Department"].Rows.Add(newRow);
                dataSet.WriteXml(xmlFileName);

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public override bool PutDepartment(Department dep)
        {
            bool result = false;

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFileName);

                DataRow[] rows = dataSet.Tables["Department"].Select("DepartmentId= " + dep.DepartmentId);
                if (rows.Length > 0)
                {
                    rows[0]["DepartmentName"] = dep.DepartmentName;
                    

                    dataSet.WriteXml(xmlFileName);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        public override bool DeleteDepartment(Department dep)
        {
            bool result = false;

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFileName);
                DataRow[] rows = dataSet.Tables["Department"].Select("DepartmentId= '" + dep.DepartmentId + "'");
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    dataSet.WriteXml(xmlFileName);

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

       

        public override DataTable GetEmlployee()
        {
            DataTable dt = new DataTable();
            DataSet dataSet = new DataSet();
            if (File.Exists(xmlFileName))
            {
                dataSet.ReadXml(xmlFileName, XmlReadMode.InferSchema);
                if (dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables["Employee"];

                }
            }

            return dt;
        }

       

        public override bool PostEmlployee(Employee emp)
        {
            bool result = false;

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFileName);
                int lastID = 0;
                if (dataSet.Tables["Employee"].Rows.Count > 0)
                {
                    //lastID = Convert.ToInt32(dataSet.Tables["Department"].Rows[dataSet.Tables["Department"].Rows.Count - 1]);
                    lastID = dataSet.Tables["Employee"].Rows.Count;
                }

                DataRow newRow = dataSet.Tables["Employee"].NewRow();
                newRow["EmployeeId"] = lastID + 1; // Set the new ID to the last ID + 1
                newRow["EmployeeName"] = emp.EmployeeName;
                newRow["Department"] = emp.Department;
                newRow["DateOfJoining"] = emp.DateOfJoining;
                newRow["PhotoFileName"] = emp.PhotoFileName;



                dataSet.Tables["Employee"].Rows.Add(newRow);
                dataSet.WriteXml(xmlFileName);

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public override bool PutEmployee(Employee emp)
        {
            bool result = false;

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFileName);

                DataRow[] rows = dataSet.Tables["Employee"].Select("EmployeeId= " + emp.EmployeeId);
                if (rows.Length > 0)
                {
                    rows[0]["EmployeeName"] = emp.EmployeeName;
                    

                    dataSet.WriteXml(xmlFileName);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public override bool DeleteEmployee(Employee emp)
        {
            bool result = false;

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFileName);
                DataRow[] rows = dataSet.Tables["Employee"].Select("EmployeeId= '" + emp.EmployeeId + "'");
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    dataSet.WriteXml(xmlFileName);

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
    }

