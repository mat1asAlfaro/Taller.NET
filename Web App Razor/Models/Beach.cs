namespace tarea_4.Models
{
  public class Beach : TourismItem
  {
    public string? Location { get; set; }
    public string? Type { get; set; }
    public List<string>? Activities { get; set; }
    public List<string>? Facilities { get; set; }
  }
}


