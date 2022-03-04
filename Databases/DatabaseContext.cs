using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Entities_Learning.Databases.Tables;

namespace Entities_Learning.Databases
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(string con) : base(con)
        { }

        static DatabaseContext()
        {
            //Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>());

            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>());

            //Database.SetInitializer(new System.Data.Entity.CreateDatabaseIfNotExists<DatabaseContext>());
        }

        public System.Data.Entity.DbSet<Person> Persons { get; set; }
    }
}
