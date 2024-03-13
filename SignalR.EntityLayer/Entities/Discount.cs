namespace SignalR.EntitiyLayer.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public string Amoun { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
