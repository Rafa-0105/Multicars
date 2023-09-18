using System.ComponentModel.DataAnnotations;

namespace Multicars.Models.BD
{
    public class Cliente
    {
        [Key]
        [Required]
        [Display(Name = "CNH do comprador")]
        public string CNH { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Nome completo")]
        public string nome { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Data de Nascimento")]

        public DateTime Data_Nasc { get; set; }
    }
}
