namespace LocalizationDemo.Domain.Models.Forms;

public class I18nListFormElementStructure
{
    public int Id { get; set; }

    public int FormElementId { get; set; }
    public string CultureCode { get; set; }

    public string Description { get; set; }
}