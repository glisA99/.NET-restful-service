using EPOSProject.Models;
using EPOSProject.Data;
using Microsoft.EntityFrameworkCore;

namespace EPOSProject.Services;

public class ProfessorService : IService<Professor>
{
    private readonly ProjectContext _context;

    public ProfessorService(ProjectContext context)
    {
        _context = context;
    }

    public ICollection<Professor> GetAll() {
        return _context.Professor.AsNoTracking().ToList();
    }

    public Professor? GetByID(int id) {
        return _context.Professor.AsNoTracking().SingleOrDefault(p => p.Id == id);
    }

    public void Delete(int id) {
        var professor = _context.Professor.Find(id);
        if (professor is not null) {
            _context.Professor.Remove(professor);
            _context.SaveChanges();
        } else throw new System.Exception("Invalid professor ID!");
    }

    public Professor Create(Professor professor) {
        _context.Professor.Add(professor);
        _context.SaveChanges();

        return professor;
    }

}