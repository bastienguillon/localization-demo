namespace LocalizationDemo.Domain.Models.Forms;

public class I18nRangeFormElementStructure
{
    public int Id { get; set; }
    public int FormElementId { get; set; }
    public string CultureCode { get; set; }

    public string MinLabel { get; set; }
    public string MaxLabel { get; set; }
}