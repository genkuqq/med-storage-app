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
        public int TransferId { get; set; }
        public string TransferCreator { get; set; }
        public string TransferDestination { get; set; }
        public DateTime TransferDate { get; set; }
        public TransferStatus TransferStatus { get; set; }
        public List<ProductTransfer> Products { get; set; } = new List<ProductTransfer>();
    }
}
