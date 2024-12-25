namespace BackEnd.Domain.Models
{
    public class TextTranslationModel : BaseModel
    {
        public required int MultiLanguageTextId { get; set; }
        public required int LanguageId { get; set; }
        public required string Value { get; set; }
    }
}