namespace Med_Storage_App.Entities
{
    public enum TransferStatus
    {
        Ongoing,
        Returning,
        Completed,
        Canceled
    }
    public class Transfer
    {
        public int Id { get; set; }
        public string TransferCreator { get; set; }
        public string TransferDestination { get; set; }
        public DateTime TransferDate { get; set; }
        public TransferStatus TransferStatus { get; set; } = TransferStatus.Ongoing;
        public List<Product> Products { get; set; } = new List<Product>();
        public int QuantitySent { get; set; }
        public int QuantityReturned { get; set; }
    }
}
