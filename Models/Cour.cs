using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminScol.Models
{
    public class Cour
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nom du Cours")]
        public string? NomCours { get; set; }
        public string? Description { get; set; }


        [ForeignKey("Classe")]
        [Display(Name = "Classes")]
        public int ClasseId { get; set; }
        public Classe? Classe { get; set; }

        public List<CourProfesseur> CourProfesseurs { get; set; } = new List<CourProfesseur>();

        [Display(Name = "Professeurs")]
        public List<int>? SelectedProfesseurIds { get; set; }


    }
}
