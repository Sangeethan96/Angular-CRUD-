using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using DataAccessLayer;


namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseControllercs : Controller
    {
        protected DataAccessLayer.Data DataAcces;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public BaseControllercs(IConfiguration configuration)
        {
            _configuration = configuration;


            
            //if (DataAcces == null)
             //   DataAcces = new XML(connectionString: configuration.GetConnectionString("database"));


            

            /*

            IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "Firebase Database Secret", 
            BasePath = "Firebase Database URL"
        };
        IFirebaseClient client; */

            


            //SQL DATABASE

            //ForSQL

            
            if (DataAcces == null)
                DataAcces = new SQLDB(connectionString:configuration.GetConnectionString("EmployeeAppCon"));

            

            
            
            
            

        }
        public BaseControllercs(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            

            if (DataAcces == null)
                DataAcces = new XML(connectionString: configuration.GetConnectionString("database"));
            


            //SQL DATABASE
            /*
            if (DataAcces == null)
                DataAcces = new SQLDB(connectionString:configuration.GetConnectionString("EmployeeAppCon"));
            
            */


        }
    }
}
