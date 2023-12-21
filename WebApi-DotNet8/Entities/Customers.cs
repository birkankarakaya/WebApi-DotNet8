namespace WebApi_DotNet8.Entities
{
    public class Customers
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime CustomerBirthDate { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerPhone { get; set; }
        public bool CustomerStatus { get; set; }
        public bool IsDelete { get; set; }

    }
}
