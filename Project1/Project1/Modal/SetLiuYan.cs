using System.ComponentModel.DataAnnotations;

namespace Project1.Modal
{
    public class SetLiuYan
    {
        [Key]
        public int LiuYanId { get; set; }

        public string UserName { get; set; }
        public string LiuYanTitle { get; set; }
        public string LiuYanText { get; set; }
        public string UserHome { get; set; }
        public string LiuYanAnesw { get; set; }

        public DateTime LiuYanDate { get; set; }
    }
}
