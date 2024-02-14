using LocalizationDemo.Domain.Models.Products;

namespace LocalizationDemo.Domain.Models.Shopping;

public sealed class LocalizedShoppingCart
{
    public Guid Id { get; set; }

    public sealed class LocalizedShoppingCartProduct
    {
        public Guid ShoppingCartId { get; set; }
        public LocalizedShoppingCart ShoppingCart { get; set; }

        public int ProductId { get; set; }
        public LocalizedProduct Product { get; set; }
    }

    public IEnumerable<LocalizedShoppingCartProduct> Products { get; set; } = new List<LocalizedShoppingCartProduct>();
}