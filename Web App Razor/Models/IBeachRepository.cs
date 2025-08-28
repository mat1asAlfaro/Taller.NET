namespace tarea_4.Models
{
  public interface IBeachRepository
  {
    public Beach GetBeachById(string id);
    public IList<Beach> GetAllBeaches();
  }
}


