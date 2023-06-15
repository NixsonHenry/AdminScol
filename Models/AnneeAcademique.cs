using System.ComponentModel.DataAnnotations;

namespace AdminScol.Models
{
    public class AnneeAcademique
    {

        [Key]
        public int Id { get; set; }
        public string? AnneeScolaire { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Début")]
        public DateTime DateDebut { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Fin")]
        public DateTime DateFin { get; set; }
        public bool Statut { get; set; }

        public ICollection<Classe>? Classes { get; set; }
    }
}
