namespace tarea_4.Models
{
  public class City : TourismItem
  {
    public string? Country { get; set; }
    public int? Population { get; set; }
    public List<string>? Attractions { get; set; }
    public List<string>? TraditionalFoods { get; set; }
  }
}