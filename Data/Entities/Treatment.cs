namespace ProyectoParcial2.Data.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public int MedicineId { get; set; } // Clave foránea
        public int DiseaseId { get; set; } // Clave foránea

        public Medicine? Medicine { get; set; }
        public Disease? Disease { get; set; }
    }
}
