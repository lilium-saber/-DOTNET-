using System.ComponentModel.DataAnnotations;

namespace Project1.Modal
{
    public class TextEssayType
    {
        [Key]
        public int EssayId { get; set; }

        public string EssayNub { get; set; }
        public string EssayType { get; set; }

        public DateTime AddTextDate { get; set; }
    }
}
