using NameCollectionTool.Dtos;

namespace NameCollectionTool.Models
{
    public class GeneratorViewModel
    {
        public List<PersonNameDto> PersonNames { get; set; }
        public List<PlaceNameDto> PlaceNames { get; set; }
        public List<TitleNameDto> TitleNames { get; set; }
        public List<SpellNameDto> SpellNames { get; set; }
        public List<ArtefactNameDto> ArtefactNames { get; set; }
        public List<OtherNameDto> OtherNames { get; set; }
        public PersonGenerateParams PersongeneratorParams { get; set; }
    }

    public class PersonGenerateParams
    {
        List<string> SelectedTags { get; set; }
        public bool CanBeMale { get; set; }
        public bool CanBeFemale { get; set; }
        public bool CanBeUnisex { get; set; }
        public int GenerateAmount { get; set; }

        public List<PersonNameDto> PersonNames { get; set; }
    }
}
