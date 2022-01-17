using EPOSProject.Models;
using EPOSProject.Data;
using Microsoft.EntityFrameworkCore;

namespace EPOSProject.Services;

public class ProjectService : IService<Project>
{
    private readonly ProjectContext _context;

    public ProjectService(ProjectContext context)
    {
        _context = context;
    }

    public ICollection<Project> GetAll() {
        return _context.Project.AsNoTracking().ToList();
    }

    public Project? GetByID(int id) {
        return _context.Project.AsNoTracking().SingleOrDefault(p => p.Id == id);
    }

    public void Delete(int id) {
        var Project = _context.Project.Find(id);
        if (Project is not null) {
            _context.Project.Remove(Project);
            _context.SaveChanges();
        } else throw new System.Exception("Invalid Project ID!");
    }

    public Project Create(Project Project) {
        _context.Project.Add(Project);
        _context.SaveChanges();

        return Project;
    }

    public void AddStudent(int id, Student student) {
        var project = _context.Project.Find(id);
        if (project is not null) {
            if (project.Students is null) {
                project.Students = new List<Student>();
                project.Students.Add(student);
            }else {
                project.Students.Add(student);
                _context.Project.Update(project);
            }
            _context.SaveChanges();
        } else throw new System.Exception("Invalid Project ID!");
    }

}