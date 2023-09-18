using System.ComponentModel.DataAnnotations;

namespace Multicars.Models.BD
{
    public class Alugueis
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public string CNH { get; set; }

        [Required]
        [Display(Name = "Carro")]
        public int id_carro { get; set; }

        [Required]
        [Display(Name = "Valor da Diária")]
        public decimal valor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Retira do veiculo")]
        public DateTime Data_alugada { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de devolução")]
        public DateTime Data_retorno { get; set; }
    }
}
