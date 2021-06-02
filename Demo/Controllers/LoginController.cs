using Microsoft.AspNetCore.Mvc;
using ControlVee.WebAPI.Angular.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Demo
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly string cstring = @"Data Source=(localdb)\MSSQLLocalDB;Database=Demo;Integrated Security=True";
        private DataAccess context;
     

        public LoginController()
        {
        }

        

        [HttpGet]
        [Route("simulateSale")]
        public int SimulateSale()
        {
            int success = 0;
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = cstring;

                context = new DataAccess(connection);

                if (context.VerifyLoginFromDb())
                    success = 1;
            };

            return success;
        }

       
    }
}
