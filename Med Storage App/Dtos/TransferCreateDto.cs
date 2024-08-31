namespace Med_Storage_App.Dtos
{
    public class TransferCreateDto
    {
        public string CreatorName { get; set; }
        public string DestinationName { get; set; }
        public List<TransferItemDto> TransferItems { get; set; }
    }
}
