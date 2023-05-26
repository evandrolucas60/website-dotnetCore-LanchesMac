using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("CartItens")]
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Snack Snack { get; set; }
        public int Quantity { get; set; }

        [StringLength(200)]
        public string CartId { get; set; }
    }
}
