using Microsoft.AspNetCore.Mvc;
using EPOSProject.Services;
using EPOSProject.Models;

// ROUTE: https://localhost:{PORT}/project

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{

    private readonly ProjectService _service;

    public ProjectController(ProjectService service)
    {
        this._service = service;
    }

    [HttpGet]
    public IEnumerable<Project> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Project> GetByID(int id)
    {
        var Project = _service.GetByID(id);

        if (Project is null)
        {
            return NotFound();
        }

        return Project;
    }

    [HttpPost]
    public IActionResult Create(Project _Project)
    {
        var Project = _service.Create(_Project);
        return CreatedAtAction(nameof(Create), new { id = Project!.Id }, Project);
    }

    [HttpPut("{id}/addstudent")]
    public IActionResult AddStudent(int id, Student student) {
        var Project = _service.GetByID(id);

        if (Project is null)
        {
            return BadRequest();
        }

        try {
            _service.AddStudent(id, student);
            return NoContent();
        } catch(System.Exception ex) {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Project = _service.GetByID(id);

        if (Project is not null)
        {
            _service.Delete(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

}