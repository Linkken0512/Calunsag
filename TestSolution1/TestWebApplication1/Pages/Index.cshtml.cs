using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace TestWebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Id_input { get; set; }
        [BindProperty]
        public string Name_input { get; set; }
        public IEnumerable<testModel> List {get; set;}
        public class testModel
        {
            public string Id1 { get; set; }
            public string Name1 { get; set; }            
        }


        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;


            var con = new SqlConnection(_config.GetConnectionString("Test"));
            List = con.Query<testModel>("select [Id] as Id1,[Name] as Name1 from Test ");                       
        }
        public IActionResult OnPostCreate()
        {
            var con = new SqlConnection(_config.GetConnectionString("Test"));
            var New = con.Query("insert into [dbo].[Test] ([Id],[Name]) values (@Id, @Name)",
            new
            {
                @Id = Id_input,
                @Name = Name_input
            } );
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate()
        {
            var con = new SqlConnection(_config.GetConnectionString("Test"));
            var New = con.Query("update Test set  [Name] = isnull (@Name,[Name]) where [Id] = @Id",
            new
            {
                @Id = Id_input,
                @Name = Name_input
            });
            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            var con = new SqlConnection(_config.GetConnectionString("Test"));
            var New = con.Query("delete from Test where [Id] = @Id",
            new
            {
                @Id = Id_input,
                
            });
            return RedirectToPage();
        }

        public IActionResult OnPostSearch()
        {
            var con = new SqlConnection(_config.GetConnectionString("Test"));
            List = con.Query<testModel>("select [Id] as Id1,[Name] as Name1 from Test where [Name] like '%' + @Keyword + '%'",
            new
            {
                @Keyword = Name_input,

            });
            return Page();
        }
        public IActionResult all()
        {

            var con = new SqlConnection(_config.GetConnectionString("Test"));
            List = con.Query<testModel>("select [Id] as Id1,[Name] as Name1 from Test ");
            return Page();
        }


        public void OnGet()
        {

        }
    }
}