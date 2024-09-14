namespace Med_Storage_App.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int No { get; set; }
        public int SerialNo { get; set; }
        public string? LotNo { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
