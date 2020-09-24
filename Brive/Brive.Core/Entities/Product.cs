namespace Brive.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
