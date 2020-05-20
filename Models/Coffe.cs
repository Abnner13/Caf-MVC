using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    public class Coffe
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Title { get; set; }

        [Display(Name = "Criado em:"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
       
        [Display(Name = "Preço")]
        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Display(Name = "Intensidade")]
        public int Intensity { get; set; }
        public string Aroma { get; set; }
        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        [Display(Name = "Como você toma seu café")]
        public string HowToTake { get; set; }

    }
}
