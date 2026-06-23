using Microsoft.AspNetCore.Mvc;
using HMS.Modules.Appointments.Domain;

namespace HMS.Modules.Appointments.Api;

[ApiController]
[Route("api/appointments")]
public class AppointmentsController : ControllerBase
{
    private static readonly List<Appointment> _appointments = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_appointments);
    }

    [HttpPost]
    public IActionResult Create(CreateAppointmentRequest request)
    {
        var appointment = new Appointment(Guid.NewGuid(), request.PatientId, request.DoctorId, request.StartTime, request.EndTime);
        _appointments.Add(appointment);
        return Ok(appointment);
    }
}

public record CreateAppointmentRequest(Guid PatientId, Guid DoctorId, DateTime StartTime, DateTime EndTime);
