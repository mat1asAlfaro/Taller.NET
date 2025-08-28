namespace tarea_4.Models
{
  public class Hotel : TourismItem
  {
    public string? Location { get; set; }
    public int? Category { get; set; }
    public float? PricePerNight { get; set; }
    public List<string>? Amenities { get; set; }
  }
}