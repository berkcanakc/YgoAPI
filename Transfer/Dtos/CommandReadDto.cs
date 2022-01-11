namespace Transfer.Dtos
{
    public class CommandReadDto
    {
        public int Dbnm { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public int? atk { get; set; }
        public int? def { get; set; }
        public int? level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }
        public int? scale { get; set; }
        public int? linkval { get; set; }
    }
}
