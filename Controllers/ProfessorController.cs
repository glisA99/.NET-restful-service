using Microsoft.AspNetCore.Mvc;
using EPOSProject.Services;
using EPOSProject.Models;

// ROUTE: https://localhost:{PORT}/professor

[ApiController]
[Route("[controller]")]
public class ProfessorController : ControllerBase
{

    private readonly ProfessorService _service;

    public ProfessorController(ProfessorService service)
    {
        this._service = service;
    }

    [HttpGet]
    public IEnumerable<Professor> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Professor> GetByID(int id)
    {
        var professor = _service.GetByID(id);

        if (professor is null)
        {
            return NotFound();
        }

        return professor;
    }

    [HttpPost]
    public IActionResult Create(Professor _professor)
    {
        var professor = _service.Create(_professor);
        return CreatedAtAction(nameof(Create), new { id = professor!.Id }, professor);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var professor = _service.GetByID(id);

        if(professor is not null)
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