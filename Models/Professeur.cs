namespace AdminScol.Models
{
    public class Professeur
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Phone { get; set; }
        public string? Sexe { get; set; }
        public string? Email { get; set; }

        public List<CourProfesseur>? CourProfesseurs { get; set; } // Navigation property for the many-to-many relationship

    }
}
