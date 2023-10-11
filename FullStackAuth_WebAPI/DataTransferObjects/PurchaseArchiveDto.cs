namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class PurchaseArchiveDto
    {
        public string UserId { get; set; }
        public string PurchasedGameTitle { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PurchaseAmount { get; set; }
    }
}
