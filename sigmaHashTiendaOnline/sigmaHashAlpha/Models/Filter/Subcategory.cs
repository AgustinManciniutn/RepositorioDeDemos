namespace sigmaHashAlpha.Models.Filter;

public class Subcategory
{
    public Subcategory(int id, string value, int? count)
    {
        Id = id;
        Value = value;
        Count = count;
    }

    public int Id { get; set; }
    public string Value { get; set; }
    public int? Count { get; set; }

}
