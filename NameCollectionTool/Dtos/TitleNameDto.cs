namespace NameCollectionTool.Dtos
{
    public class TitleNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrefix { get; set; } // False means it is a suffix
    }
}
