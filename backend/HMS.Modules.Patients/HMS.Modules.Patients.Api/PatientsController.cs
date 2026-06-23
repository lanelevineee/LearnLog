using Microsoft.AspNetCore.Mvc;
using HMS.Modules.Patients.Domain;

namespace HMS.Modules.Patients.Api;

[ApiController]
[Route("api/patients")]
public class PatientsController : ControllerBase
{
    // Simplified for now, should use Application layer and Repository
    private static readonly List<Patient> _patients = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_patients);
    }

    [HttpPost]
    public IActionResult Create(CreatePatientRequest request)
    {
        var patient = new Patient(Guid.NewGuid(), request.FirstName, request.LastName, request.DateOfBirth, request.Gender, request.Email);
        _patients.Add(patient);
        return Ok(patient);
    }
}

public record CreatePatientRequest(string FirstName, string LastName, DateTime DateOfBirth, string Gender, string Email);
