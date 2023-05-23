namespace Sales.Application.App_Dto
{
    public record StockDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
        public int? taxRate { get; set; }
    }
}
