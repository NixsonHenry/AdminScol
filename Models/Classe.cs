using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminScol.Models
{
    public class Classe
    {
        [Key]
        public int Id { get; set; }
        public string? Niveau { get; set; }
        public string? Section { get; set; }

        [ForeignKey("AnneeAcademique")]
        public int AnneeAcademiqueId { get; set; }

        public AnneeAcademique? AnneeAcademique { get; set; }
    }
}
