using System.ComponentModel.DataAnnotations;

namespace nguyencongthang_231230913_de01.Models
{
    public class nctComputer
    {
        [Key]
        public int? nctComId { get; set; }
        public string? nctComName { get; set; }
        public double? nctComPrice { get; set; }
        public string? nctComImage { get; set; }
        public bool? nctComStatus { get; set; }
    }
}
