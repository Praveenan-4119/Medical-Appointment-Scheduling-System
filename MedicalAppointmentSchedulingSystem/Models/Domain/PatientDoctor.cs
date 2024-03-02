namespace MedicalAppointmentSchedulingSystem.Models.Domain
{
    public class PatientDoctor
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
