namespace Sales.Application.App_Dto
{
    public record ProductDto
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public int? taxRate { get; set; }
    }
}
