namespace Brive.Core.Entities
{
    public partial class SucursalB : BaseEntity
    {
        public string ProductName { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
