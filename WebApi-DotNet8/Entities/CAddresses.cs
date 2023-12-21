namespace WebApi_DotNet8.Entities
{
    public class CAddresses
    {
        public int id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerID { get; set; }
        public int AddressTypeID { get; set; }
        public string AddressDescription { get; set; }
        public bool AddressStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}
