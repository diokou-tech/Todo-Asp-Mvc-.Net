namespace Todo_Asp_Mvc.Net.Models
{
    public class Metadata
    {
        public int CurrentPage { get; set; } = 1;
        public decimal TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
        public int? NextPage { get; set; }
        public int? PrevPage { get; set; }
    }
}