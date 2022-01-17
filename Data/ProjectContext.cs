using Microsoft.EntityFrameworkCore;
using EPOSProject.Models;

namespace EPOSProject.Data;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
    {
    }

    public DbSet<Project> Project => Set<Project>();
    public DbSet<Student> Student => Set<Student>();
    public DbSet<Professor> Professor => Set<Professor>();

}