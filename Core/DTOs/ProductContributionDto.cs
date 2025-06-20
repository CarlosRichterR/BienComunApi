namespace BienComun.Core.DTOs
{
    public class ProductContributionDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal TotalContributed { get; set; }
        public int Quantity { get; set; }
        // Puedes agregar más campos según lo que requiera el frontend
    }
}
