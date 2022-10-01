namespace Services.ProductDetail.Domain.Entities
{
    public class ProductsDetail : Product
    {
        public string LongDescription { get; set; }

        public virtual ICollection<ProductExtras> ProductExtras { get; set; }

        public ProductsDetail()
        {
            ProductExtras = new HashSet<ProductExtras>();
        }

        public ProductsDetail(string longDescription, ICollection<ProductExtras> productExtras) : this()
        {
            LongDescription = longDescription;
            ProductExtras = productExtras;
        }
    }
}
