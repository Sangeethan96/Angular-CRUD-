using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Response
    {

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Department PostDepartment { get; set; }
    }
        
}
