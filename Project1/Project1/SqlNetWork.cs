using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Project1.Modal;
using Project1.Pages;

namespace Project1
{
    public class SqlNetWork : DbContext
    {
        public SqlNetWork(DbContextOptions<SqlNetWork> options) : base(options)
        {}

        public DbSet<User> users { get; set; }
        public DbSet<EssayHire> essayHires { get; set; }
        public DbSet<PingLun> pingLuns { get; set; }
        public DbSet<TextEssayType> textEssayTypes { get; set; }
        public DbSet<Modal.Essay> Essays { get; set; }
        public DbSet<SetLiuYan> liuYans { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<EssayHire>().ToTable("EssayHire");
            modelBuilder.Entity<PingLun>().ToTable("PingLun");
            modelBuilder.Entity<TextEssayType>().ToTable("TextEssayType");
            modelBuilder.Entity<Modal.Essay>().ToTable("Essay");
            modelBuilder.Entity<SetLiuYan>().ToTable("SetLiuYan");
        }

        public bool CheckUser(string name)
        {
            Console.WriteLine("Check running");
            var user = users.SingleOrDefault(b => b.UserName == name);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task CreateEssay0(string title, string text)
        {
            string shor = "";
            if(text.Length <= 20)
            {
                shor = text;
            }
            else
            {
                shor = text.Substring(0, 20);
            }
            var essay = new Modal.Essay { EssayPropularity = 0,
                                               EssayPingLunNum = 0,
                                               EssayTitle = title,
                                               ShortWord = shor,
                                               EssayText = text,
                                               EssayType = "Essay",
                                               EssayDate = System.DateTime.Now
            };
            Essays.Add(essay);
            await SaveChangesAsync();
        }

        public async Task CreatePL(string user, string essayname , string text)
        {
            var pl = new PingLun { UserName = user, PingLunText = text, PingLunDate = System.DateTime.Now, PingLunTitle = "0", UserHome = "0", EssayNub = essayname };
            var ess = Essays.SingleOrDefault(b => b.EssayTitle == essayname);
            ess.PingLuns.Add(pl);
            await SaveChangesAsync();
        }

        public async Task<bool> CheckPL(string essayname)
        {
            var esspl = Essays.Include(e => e.PingLuns).SingleOrDefault(b => b.EssayTitle == essayname);
            if(esspl == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<ICollection<PingLun>> GetAllPL(string essayname)
        {
            return Essays.SingleOrDefault(b => b.EssayTitle == essayname).PingLuns;
        }

        public string GetEssay(string name)
        {
            var ess = Essays.SingleOrDefault(b => b.EssayTitle == name);
            if (ess == null)
            {
                return "NUll";
            }
            else
            {
                return ess.EssayText;
            }

        }

        public bool CheckEssayName(string name)
        {
            var ess = Essays.SingleOrDefault(b => b.EssayTitle == name);
            if (ess == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task CreateUser(string name, string pw)
        {
            var user = new User { UserName = name, UserPassWord = pw, CreateUserDate = System.DateTime.Now };
            users.Add(user);
            await SaveChangesAsync();
            Console.WriteLine("Create running");
        }

        public async Task CreateEssay(string title, string content, string type, string name)
        {
            var essay = new Modal.Essay { EssayPropularity = 0,
                                    EssayPingLunNum = 0,
                                    EssayTitle = title,
                                    ShortWord = content.Substring(0, 20),
                                    EssayText = content,
                                    EssayType = type,
                                    EssayDate = System.DateTime.Now
            };
            Essays.Add(essay);
            await SaveChangesAsync();
            Console.WriteLine("Create running");
        }

        public bool CheckName(string name)
        {
            var user = users.SingleOrDefault(b => b.UserName == name);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckPw(string pw)
        {
            var user = users.SingleOrDefault(b => b.UserPassWord == pw);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
