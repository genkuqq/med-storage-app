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
        public int Id { get; set; }
        public string CreatorName { get; set; }
        public string DestinationName { get; set; }
        public TransferStatus TransferStatus { get; set; }
        public DateTime TransferDate { get; set; }
        public List<TransferItemModel> TransferItems { get; set; } = new List<TransferItemModel>();
    }
}
