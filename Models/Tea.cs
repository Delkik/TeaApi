namespace TeaApi.Models
{
    public class Tea
    {
        public string? TeaName { get; set; }
        public int TeaId { get; set; }
        public int Caffeine { get; set; }
        public int Calories { get; set; }
        public string? Origin { get; set; }
    }
}
