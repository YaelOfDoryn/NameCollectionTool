namespace NameCollectionTool.Models
{
    public class CollectionsViewModel
    {
        public CollectionsStatistics Statistics { get; set; }
    }

    public class CollectionsStatistics
    {
        public int PersonNamesCount { get; set; }
        public int PlaceNamesCount { get; set; }
        public int TitleNamesCount { get; set; }
        public int SpellNamesCount { get; set; }
        public int ArtefactNamesCount { get; set; }
    }
}
