namespace LocalizationDemo.Domain.Models.Forms;

public abstract class FormElementStructure
{
    public int Id { get; set; }
    public string FormElementStructureDiscriminator { get; set; }
}

public class RangeFormElementStructure : FormElementStructure
{
    public string ReferenceCulture { get; set; }
    public List<I18nRangeFormElementStructure> Translations { get; set; }
}

public class ListFormElementStructure : FormElementStructure
{
    public string ReferenceCulture { get; set; }
    public List<I18nListFormElementStructure> Translations { get; set; }
}