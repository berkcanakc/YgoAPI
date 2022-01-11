using System.ComponentModel.DataAnnotations;

namespace Transfer.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string desc { get; set; }
        public int? atk { get; set; }
        public int? def { get; set; }
        public int? level { get; set; }
        [Required]
        public string race { get; set; }
        public string attribute { get; set; }
        public int? scale { get; set; }
        public int? linkval { get; set; }
    }
}
