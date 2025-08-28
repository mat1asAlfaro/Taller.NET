namespace tarea_4.Models
{
  public interface IExcursionRepository
  {
    public Excursion GetExcursionById(string id);
    public IList<Excursion> GetAllExcursions();
  }
}


