namespace Med_Storage_Frontend.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int No { get; set; }
        public int SerialNo { get; set; }
        public string LotNo { get; set; }
        public int Quantity { get; set; }

        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpiratioDate { get; set; }
    }
}
