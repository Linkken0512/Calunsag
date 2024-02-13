#nullable disable
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

namespace CalunsagBlazorApp.Data
{
    public class Class
    {
    }
    public class Connection : Profiles
    {
        private readonly IConfiguration config;
        private readonly SqlConnection conn;

        public Connection(IConfiguration _config)
        {
            config = _config;
            conn = new SqlConnection(config.GetConnectionString("db"));
        }
        public void Create()
        {
           
            conn.Query("[createProf]", new
            {
                @FirstName = FirstName,
                @LastName = LastName,
                @Age = Age,
                @Lvl = Lvl

            }, commandType: CommandType.StoredProcedure);            
        }
        public void Update(Profiles disprof)
        {            
            conn.Query("[updateProf]", new
            {
                @Id = disprof.Id,
                @FirstName = disprof.FirstName,
                @LastName = disprof.LastName,
                @Age = disprof.Age,
                @Lvl = disprof.Lvl

            }, commandType: CommandType.StoredProcedure);           
        }
        public IEnumerable<Profiles> Display()
        {
            var result = conn.Query<Profiles>("[displayProf]", new
            {
                @Id = Id,
                @FirstName = FirstName,
                @LastName = LastName,
                @Age = Age,
                @Lvl = Lvl

            }, commandType: CommandType.StoredProcedure);
            
            return result;
        }
        public void Delete()
        {            
            conn.Query("[deleteProf]", new
            {
                @Id = Id

            }, commandType: CommandType.StoredProcedure);
        }
    }
    public class Profiles
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Lvl { get; set; }
    }
    public class Stats
    {
        public int StatId { get; set; }
        public int str { get; set; }
        public int agi { get; set; }
        public int mgc { get; set; }
        public int knw { get; set; }
        public int elm { get; set; }
        public int title { get; set; }
    }
}
