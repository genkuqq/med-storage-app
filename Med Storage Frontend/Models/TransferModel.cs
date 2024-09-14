namespace Med_Storage_Frontend.Models
{
    public enum TransferStatus
    {
        Ongoing,
        Returning,
        Completed,
        Canceled
    }
    public class TransferModel
    {
        public int TransferId { get; set; }
        public string TransferCreator { get; set; }
        public string TransferDestination { get; set; }
        public TransferStatus TransferStatus { get; set; }
        public DateTime TransferDate { get; set; }
        public List<ProductTransferModel> Products { get; set; } = new List<ProductTransferModel>();
    }
}
