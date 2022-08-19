using System.ComponentModel.DataAnnotations;

namespace WebAPI__CodeFirst.Classes
{
    public class Customer
    {
        [Key]
        public int customer_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
