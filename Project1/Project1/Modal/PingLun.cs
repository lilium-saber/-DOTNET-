using System.ComponentModel.DataAnnotations;

namespace Project1.Modal
{
    public class PingLun
    {
        [Key]
        public int PingLunId { get; set; }

        public string UserName { get; set; }
        public string PingLunTitle { get; set; }
        public string PingLunText { get; set; }
        public string UserHome { get; set; }
        public string EssayNub { get; set; }

        public DateTime PingLunDate { get; set; }
    }
}
