using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Snacks")]
    public class Snack
    {
        [Key]
        public int SnackId { get; set; }

        [Required(ErrorMessage ="O nome do lanche deve ser informado")]
        [Display(Name ="Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string SnackName { get; set;}

        [Required(ErrorMessage ="A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage ="Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
        public string ShortDescription { get; set;}

        [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada não pode exceder {1} caracteres")]
        public string DetailDescription { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage ="O preço deve estar entre 1 e 999,99")]
        public decimal Price { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImageUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name ="Preferido?")]
        public bool IsFavoriteSnack { get; set; }

        [Display(Name ="Estoque")]
        public bool InStock { get; set; }

        //foreign key
        [Display(Name ="Categorias")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}