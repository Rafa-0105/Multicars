using System.ComponentModel.DataAnnotations;

namespace Multicars.Models.BD
{
    public class Grupos
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Nome do Grupo")]
        public string nome { get; set; }

        [Required]
        [Display(Name = "Valor da Diária")]
        public decimal valor { get; set; }
    }
}