using HMS.Shared.Domain;

namespace HMS.Modules.Appointments.Domain;

public class Appointment : AggregateRoot<Guid>
{
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public string Status { get; private set; }

    private Appointment() { }

    public Appointment(Guid id, Guid patientId, Guid doctorId, DateTime startTime, DateTime endTime) : base(id)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        StartTime = startTime;
        EndTime = endTime;
        Status = "Scheduled";
    }

    public void Cancel() => Status = "Cancelled";
    public void Complete() => Status = "Completed";
}
