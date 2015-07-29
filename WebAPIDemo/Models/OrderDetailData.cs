namespace WebAPIDemo.Models
{
    public class OrderDetailData
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }

        //Navigate
        public virtual BookData Book { get; set; }
        public virtual OrderData Order { get; set; }
    }
}