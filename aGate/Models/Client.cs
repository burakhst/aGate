using System.ComponentModel.DataAnnotations;

namespace aGate.Models
{
    public class Client
    {
        [Key]
        public int clientID { get; set; }
        public string? clientName { get; set; }
        public string? clientAddress { get; set; }
        public int clientPhoneNumber { get; set; }

    }
}