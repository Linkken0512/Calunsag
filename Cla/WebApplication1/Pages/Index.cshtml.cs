using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        public IndexModel(ILogger<IndexModel> logger,IConfiguration config)
        {
            _logger = logger;
            _config = config;
            var conn = new SqlConnection(_config.GetConnectionString("db"));
            list = conn.Query<studentModel>("" +
                "select " +
                "[Id] as r1," +
                "[Name] as r2," +
                "[Nickname] as r3" +
                " from " +
                "[dbo].[Table1]");
        }

        public IActionResult OnPostCreate()
        {
            var conn = new SqlConnection(_config.GetConnectionString("db"));
            var asdd = conn.Query("Insert into [dbo].[Table1] ([Id],[Name],[Nickname]) values (@Id,@Name,@Nickname)",
                new { 
            @Id = Id_input,
            @Name = Name_input,
            @Nickname = NickName_input

            });


            return RedirectToPage();
        }

        public IActionResult OnPostEdit()
        {
            var conn = new SqlConnection(_config.GetConnectionString("db"));
            var asdd = conn.Query("update [dbo].[Table1] set [Name] = isnull (@Name,[Name]), [Nickname] = isnull (@Nickname,[Nickname]) where [Id] = @Id",
                new
                {
                    @Id = Id_input,
                    @Name = Name_input,
                    @Nickname = NickName_input

                });


            return RedirectToPage();
        }

        public IActionResult OnPostDelete()
        {
            var conn = new SqlConnection(_config.GetConnectionString("db"));
            var asdd = conn.Query("delete from [dbo].[Table1] where [Id] = @Id",
                new
                {
                    @Id = Id_input,

                });


            return RedirectToPage();
        }
        public IActionResult OnPostSearch()
        {
            var conn = new SqlConnection(_config.GetConnectionString("db"));
            list = conn.Query<studentModel>("SELECT [Id] as r1, [Name] as r2, [Nickname] as r3 FROM [dbo].[Table1] WHERE convert(nvarchar(50),[Id]) LIKE '%' + @Keyword + '%' OR [Name] LIKE '%' + @Keyword + '%' OR [Nickname] LIKE '%' + @Keyword + '%' ORDER BY [Name];",
                
                new
                {
                    
                    @Keyword = s_input
                    

                });


            return Page();
        }

        public IActionResult OnPostDisplay()
        {
            var conn = new SqlConnection(_config.GetConnectionString("db"));
            list = conn.Query<studentModel>("" +
                "select " +
                "[Id] as r1," +
                "[Name] as r2," +
                "[Nickname] as r3" +
                " from " +
                "[dbo].[Table1]");


                return Page();
        }

        [BindProperty]
        public int Id_input { get; set; }
        [BindProperty]
        public string Name_input { get; set; }
        [BindProperty]
        public string NickName_input { get; set; }
        [BindProperty]
        public string s_input { get; set; }

        public IEnumerable<studentModel> list { get; set; }
        public class studentModel
        {
            public int r1 { get; set; }
            public string r2 { get; set; }
            public string r3 { get; set; }
        }
        
        
        
        
        public void OnGet()
        {

        }
    }
}