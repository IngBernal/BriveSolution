namespace Brive.Core.Entities
{
    public partial class SucursalA : BaseEntity
    {
        public string ProductName { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
