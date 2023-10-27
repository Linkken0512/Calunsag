using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dapper;
using System.Data.SqlClient;

namespace TestsWebApplication1.Pages
{
    public class IndexModel : PageModel    
    {
        public IEnumerable<testModel1> List { get; set; }
        public class testModel1
        {
            public string Id1 { get; set; }
            public string Name1 { get; set; }
        }
        [BindProperty]
        public string Id_Input { get; set; }
        [BindProperty]
        public string Name_Input { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            var con = new SqlConnection(_config.GetConnectionString("DB"));
            List = con.Query<testModel1>("select [Name] as Name1, [Id] as Id1 from Test");            
        }
        public IActionResult OnPostCreate()
        {
            var con = new SqlConnection(_config.GetConnectionString("DB"));
            var d = con.Query("insert into Test([Id],[Name]) values(@Id,@Name)",
                new
                {
                    @Name = Name_Input,
                    @Id = Id_Input
                }
                );
            return RedirectToPage();
        }
        public IActionResult OnPostUpdate()
        {
            var con = new SqlConnection(_config.GetConnectionString("DB"));
            var d = con.Query("update Test set [Name] = isnull (@Name,[Name]) where [Id] = @Id",
                new
                {
                    @Name = Name_Input,
                    @Id = Id_Input
                }
                );
            return RedirectToPage();
        }
        public IActionResult OnPostDelete()
        {
            var con = new SqlConnection(_config.GetConnectionString("DB"));
            var d = con.Query("delete from Test where [Id] = @Id",
                new
                {
                   
                    @Id = Id_Input
                }
                );
            return RedirectToPage();
        }
        public IActionResult OnPostSearch()
        {
            var con = new SqlConnection(_config.GetConnectionString("DB"));
            List = con.Query<testModel1>("select [Name] as Name1, [Id] as Id1 from Test where [Name] like '%' + @Keyword + '%' or [Id] like '%' + @Keyword + '%' ",
            new
            {
                @Keyword = Name_Input
            }
            );

            return Page();
        }
        public IActionResult OnPostDisplay()
        {
           

            return RedirectToPage();
        }


        public void OnGet()
        {

        }
    }
}