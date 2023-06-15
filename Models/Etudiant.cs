using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminScol.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Naissance")]
        public DateTime DateNaissance { get; set; }

        public string Adresse { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Occupation { get; set; }

        [Display(Name = "Statut Matrimonial")]
        public string? StatutMatrimonial { get; set; }
        public string? Maladie { get; set; }


        [ForeignKey("Classe")]
        public int ClasseId { get; set; }
        public Classe? Classe { get; set; }

        public ICollection<Classe>? Classes { get; set; }

    }
}
