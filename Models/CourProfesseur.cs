namespace AdminScol.Models
{
    public class CourProfesseur
    {
        public int Id { get; set; }
        public int CourId { get; set; }
        public Cour? Cour { get; set; } // Navigation property for the Cour entity

        public int ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; } // Navigation property for the Professeur entity
    }
}
