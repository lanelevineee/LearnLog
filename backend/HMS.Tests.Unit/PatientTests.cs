using HMS.Modules.Patients.Domain;
using Xunit;

namespace HMS.Tests.Unit;

public class PatientTests
{
    [Fact]
    public void CreatePatient_ShouldInitializeCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstName = "John";
        var lastName = "Doe";
        var dob = new DateTime(1990, 1, 1);
        var gender = "Male";
        var email = "john.doe@example.com";

        // Act
        var patient = new Patient(id, firstName, lastName, dob, gender, email);

        // Assert
        Assert.Equal(id, patient.Id);
        Assert.Equal(firstName, patient.FirstName);
        Assert.Equal(lastName, patient.LastName);
        Assert.Equal(dob, patient.DateOfBirth);
        Assert.Equal(gender, patient.Gender);
        Assert.Equal(email, patient.Email);
    }
}
