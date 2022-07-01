namespace NameCollectionTool.Models
{
    public class PersonNameViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public string? Etymology { get; set; }
        public List<string> Tags { get; set; }

        public bool IsFullName()
        {
            return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Unisex
    }
}

