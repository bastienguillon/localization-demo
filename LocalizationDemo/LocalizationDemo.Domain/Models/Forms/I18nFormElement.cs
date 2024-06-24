namespace LocalizationDemo.Domain.Models.Forms;

public class I18nFormElement
{
    public int Id { get; set; }
    public int FormElementId { get; set; }
    public string CultureCode { get; set; }

    public string Name { get; set; }
}