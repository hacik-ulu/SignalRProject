namespace SignalRWebUI.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public int BasketID { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}
