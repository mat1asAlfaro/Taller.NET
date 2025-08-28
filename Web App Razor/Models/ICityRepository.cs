namespace tarea_4.Models
{
  public interface ICityRepository
  {
    public City GetCityById(string id);
    public IList<City> GetAllCities();
  }
}


