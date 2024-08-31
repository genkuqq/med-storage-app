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
        public string CreatorName { get; set; }
        public string DestinationName { get; set; }
        public TransferStatus TransferStatus { get; set; }
        public DateTime TransferDate { get; set; }
        public List<TransferItem> TransferItems { get; set; } = new List<TransferItem>();
    }
}
