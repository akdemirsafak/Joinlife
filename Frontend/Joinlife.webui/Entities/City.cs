namespace Joinlife.webui.Entities;

public sealed class City : EntityBase
{
    public string Name { get; set; }
    public Country Country { get; set; }
}
