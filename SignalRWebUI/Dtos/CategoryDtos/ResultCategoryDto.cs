namespace SignalRWebUI.Dtos.CategoryDtos
{
    // UI için çalışan Dto --> Json'dan gelen dataları eşleştirmemiz lazım.
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
    }
}
