using Microsoft.EntityFrameworkCore;

namespace DotNetSkillSchool.Models
{
    public class ApplictionContext:DbContext
    {
        public ApplictionContext(DbContextOptions<ApplictionContext> options) : base(options)
        {
        }
        DbSet<Tutorial>Tutorials { get; set; }
        DbSet<Video> Videos { get; set; }
        public DbSet<FileUpload> Files { get; set; }
    }
}
