using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

namespace Start
{
    public class App
    {
        public static IO io = new IO();
        public static void Main()
        {

            var db = new DbGeneric();
            IService<User> service = new Service<User>(db);
            User user = new User()
            {
                Name = "mehrhsad",
                LastName = "Asadi",
                Age = 19,
            };


            service.Insert(user);
            db.SaveChanges();
        }

        private static void Start()
        {
            
        }
    }
}
