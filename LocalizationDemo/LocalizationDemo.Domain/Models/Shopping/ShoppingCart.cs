using LocalizationDemo.Domain.Models.Products;

namespace LocalizationDemo.Domain.Models.Shopping;

public sealed class ShoppingCart
{
    public Guid Id { get; set; }

    public sealed class ShoppingCartProduct
    {
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public IEnumerable<ShoppingCartProduct> Products { get; set; } = new List<ShoppingCartProduct>();
}