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
    public interface IProfile
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        int Lvl { get; set; }
    }

    public class Profile : IProfile
    {
        private string id;
        private string firstName;
        private string lastName;
        private int age;
        private int lvl;
        public Profile()
        {
            id = Guid.NewGuid().ToString();
        }

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public int Lvl { get => lvl; set => lvl = value; }
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
                FirstName,
                LastName,
                Age,
                Lvl

            }, commandType: CommandType.StoredProcedure);            
        }
        public void Update(Profiles disprof)
        {            
            conn.Query("[updateProf]", new
            {
                disprof.Id,
                disprof.FirstName,
                disprof.LastName,
                disprof.Age,
                disprof.Lvl

            }, commandType: CommandType.StoredProcedure);           
        }
        public IEnumerable<Profiles> Display()
        {
            var result = conn.Query<Profiles>("[displayProf]", new
            {
                Id,
                FirstName,
                LastName,
                Age,
                Lvl

            }, commandType: CommandType.StoredProcedure);
            
            return result;
        }
        public void Delete()
        {            
            conn.Query("[deleteProf]", new
            {
                Id

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
