namespace Sales.Domain.Domain_Common
{
    public record BaseEntity
    {
        public Guid id { get; set; }
        public DateTime createDate { get; set; }
    }
}
