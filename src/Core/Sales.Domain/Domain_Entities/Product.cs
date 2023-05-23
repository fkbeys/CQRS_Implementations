using Sales.Domain.Domain_Common;

namespace Sales.Domain.Domain_Entities
{
    public record Product : BaseEntity
    {
        public string? name { get; set; }
        public string? origin { get; set; }
        public int? taxRate { get; set; }
        public int? maxLevel { get; set; }
        public int? minLevel { get; set; }
    }
}
