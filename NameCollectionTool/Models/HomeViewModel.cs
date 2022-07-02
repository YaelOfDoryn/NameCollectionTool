using NameCollectionTool.Dtos;

namespace NameCollectionTool.Models
{
    public class HomeViewModel
    {
        public List<PersonNameDto> PersonNames { get; set; }
        public List<PlaceNameDto> PlaceNames { get; set; }
        public List<TitleNameDto> TitleNames { get; set; }
        public List<SpellNameDto> SpellNames { get; set; }
        public List<ArtefactNameDto> ArtefactNames { get; set; }
        public List<OtherNameDto> OtherNames { get; set; }

    }
}
