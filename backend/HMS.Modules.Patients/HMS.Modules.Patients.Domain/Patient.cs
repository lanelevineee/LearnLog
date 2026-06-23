using HMS.Shared.Domain;

namespace HMS.Modules.Patients.Domain;

public class Patient : AggregateRoot<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Gender { get; private set; }
    public string Email { get; private set; }

    private Patient() { }

    public Patient(Guid id, string firstName, string lastName, DateTime dateOfBirth, string gender, string email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Email = email;
    }
}
