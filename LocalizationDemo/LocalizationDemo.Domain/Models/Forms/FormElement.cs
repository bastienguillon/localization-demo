namespace LocalizationDemo.Domain.Models.Forms;

public abstract class FormElement
{
    public int Id { get; set; }
    public string FormElementDiscriminator { get; set; }
    public string FormElementStructureDiscriminator { get; set; }

    public string ReferenceCulture { get; set; }
    public List<I18nFormElement> Translations { get; set; }

    public FormElementStructure FormElementStructure { get; set; }
}

public class ReviewFormElement : FormElement
{
}

public class FeedbackFormElement : FormElement
{
}