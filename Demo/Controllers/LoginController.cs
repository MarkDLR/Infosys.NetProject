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
        private readonly string cstring = @"Server=DESKTOP-9S11UIB;Database=Demo;Trusted_Connection=True";

        private DataAccess context;
     

        public LoginController()
        {
        }


        [HttpGet]
        [Route("login")]
        public int Login()
        {
            int success = 0;
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = cstring;

                context = new DataAccess(connection);

                if (context.VerifyLoginFromDb("AGoerlich","password2"))
                    success = 1;
            };

            return success;
        }

       
    }
}
