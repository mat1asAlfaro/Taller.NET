namespace tarea_4.Models
{
  public class Excursion : TourismItem
  {
    public string? Location { get; set; }
    public float? PricePerPerson { get; set; }
    public List<string>? Includes { get; set; }
    public string? Difficulty { get; set; }
  }
}