using System.ComponentModel.DataAnnotations;

namespace Project1.Modal
{
    public class EssayHire
    {
        [Key]
        public int HireId { get; set; }

        public string HireNum { get; set; }
        public string HireAddress { get; set; }
        public string HireName { get; set; }

        public DateTime HireDate { get; set; }
    }
}
