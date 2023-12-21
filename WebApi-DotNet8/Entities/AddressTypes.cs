using System.Net;

namespace WebApi_DotNet8.Entities
{
    public class AddressTypes
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public required string TypeName { get; set; }
        public bool TypeStatus { get; set; }
        public bool IsDelete { get; set; }

    }
}
