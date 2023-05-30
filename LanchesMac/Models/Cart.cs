using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class Cart
    {
        private readonly AppDbContext _context;

        public Cart(AppDbContext context)
        {
            _context = context;
        }

        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }


        public static Cart GetCart(IServiceProvider services)
        {
            //define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do contexto
            var context = services.GetService<AppDbContext>();

            //obtém ou gera o Id do carrinho
            string cartId = session.GetString("CartId")??Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CartId", cartId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new Cart(context)
            {
                CartId = cartId,
            };
        }

        public void AddToCart(Snack snack)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s=> s.Snack.SnackId == snack.SnackId &&
                s.CartId == CartId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Snack = snack,
                    Quantity = 1
                };

                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Snack snack)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s => s.Snack.SnackId == snack.SnackId &&
                s.CartId == CartId);

            var localQuantity =  0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1) 
                {
                    cartItem.Quantity--;
                    localQuantity = cartItem.Quantity;
                }
                else
                {
                    _context.CartItems.Remove(cartItem);
                }
            }

            _context.SaveChanges();
            return localQuantity;
        }
    }
}
