namespace Services.ProductDetail.Domain.Entities
{
    public class ProductDetail : Product
    {
        public string LongDescription { get; set; }

        public virtual ICollection<ProductExtras> ProductExtras { get; set; }

        public ProductDetail()
        {
            ProductExtras = new HashSet<ProductExtras>();
        }

        public ProductDetail(string longDescription, ICollection<ProductExtras> productExtras) : this()
        {
            LongDescription = longDescription;
            ProductExtras = productExtras;
        }
    }
}
