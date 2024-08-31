namespace Med_Storage_Frontend.Models
{
    public class TransferItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }
        public int Quantity { get; set; }
    }
}
