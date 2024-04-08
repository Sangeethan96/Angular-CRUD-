using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data;
using System.Security.AccessControl;

namespace DataAccessLayer
{
    public abstract class Data
    {
        private string connectionString = string.Empty;
        private string databaseName = string.Empty;

        public Data()
        {

        }
        public Data(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public abstract bool DeleteDepartment(Department departmentId);
        public abstract bool DeleteEmployee(Employee employeeId);
        public abstract DataTable GetDeparment();
        public abstract DataTable GetEmlployee();
        public abstract bool PostDepartment(Department departmentName);
        public abstract bool PostEmlployee(Employee emp);

        public abstract bool PutDepartment(Department departmentName);
        public abstract bool PutEmployee(Employee emp);
    }
}
