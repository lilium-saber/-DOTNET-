using System.ComponentModel.DataAnnotations;

namespace Project1.Modal
{
    public class Essay
    {
        [Key]
        public int EssayId { get; set; }

        public int EssayPropularity { get; set; }
        public int EssayPingLunNum { get; set; }
        public string EssayTitle { get; set; }
        public string ShortWord { get; set; }
        public string EssayText { get; set; }
        public string EssayType { get; set; }

        public DateTime EssayDate { get; set; }

        public ICollection<PingLun> PingLuns { get; set; }

    }
}
