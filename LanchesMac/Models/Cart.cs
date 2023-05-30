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
    }
}
