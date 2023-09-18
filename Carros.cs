using System.ComponentModel.DataAnnotations;

namespace Multicars.Models.BD
{
    public class Carros
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Nome da Marca")]
        public string marca { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Modelo do Carro")]
        public string modelo { get; set; }

        [Required]
        public int ano { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Cor do Carro")]
        public string cor { get; set; }

        [Required]
        public int grupo { get; set; }

        public bool disponibilidade { get; set; }
    }
}
