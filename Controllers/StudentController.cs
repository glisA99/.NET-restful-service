using Microsoft.AspNetCore.Mvc;
using EPOSProject.Services;
using EPOSProject.Models;

// ROUTE: https://localhost:{PORT}/student

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{

    private readonly StudentService _service;

    public StudentController(StudentService service)
    {
        this._service = service;
    }

    [HttpGet]
    public IEnumerable<Student> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetByID(int id)
    {
        var Student = _service.GetByID(id);

        if (Student is null)
        {
            return NotFound();
        }

        return Student;
    }

    [HttpPost]
    public IActionResult Create(Student _Student)
    {
        var Student = _service.Create(_Student);
        return CreatedAtAction(nameof(Create), new { id = Student!.Id }, Student);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Student = _service.GetByID(id);

        if(Student is not null)
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