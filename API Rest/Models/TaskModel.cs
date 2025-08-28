namespace _tarea_1b.Models
{
  public class TaskModel
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? Duration { get; set; }
    public string? Responsible { get; set; }
    public DateOnly? DueDate { get; set; }


    public TaskModel(int id, string name, string description, int duration, string responsible, DateOnly dueDate)
    {
      Id = id;
      Name = name;
      Description = description;
      this.Duration = duration;
      this.Responsible = responsible;
      this.DueDate = dueDate;
    }

    public TaskModel()
    {
    }
  }
}