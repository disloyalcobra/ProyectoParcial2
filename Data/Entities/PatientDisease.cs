namespace ProyectoParcial2.Data.Entities
{
    public class PatientDisease
    {
        public int Id { get; set; }
        public int PatientId { get; set; } // Clave foránea
        public int DiseaseId { get; set; } // Clave foránea

        public Patient? Patient { get; set; }
        public Disease? Disease { get; set; }
    }
}
