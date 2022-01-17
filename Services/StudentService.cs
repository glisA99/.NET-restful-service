using EPOSProject.Models;
using EPOSProject.Data;
using Microsoft.EntityFrameworkCore;

namespace EPOSProject.Services;

public class StudentService : IService<Student>
{
    private readonly ProjectContext _context;

    public StudentService(ProjectContext context)
    {
        _context = context;
    }

    public IEnumerable<Student> GetAll()
    {
        return _context.Student.AsNoTracking().ToList();
    }

    public Student? GetByID(int id)
    {
        return _context.Student.AsNoTracking().SingleOrDefault(p => p.Id == id);
    }

    public void Delete(int id)
    {
        var Student = _context.Student.Find(id);
        if (Student is not null)
        {
            _context.Student.Remove(Student);
            _context.SaveChanges();
        }
        else throw new System.Exception("Invalid Student ID!");
    }

    public Student Create(Student student)
    {
        _context.Student.Add(student);
        _context.SaveChanges();

        return student;
    }

}