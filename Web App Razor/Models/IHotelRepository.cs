namespace tarea_4.Models
{
  public interface IHotelRepository
  {
    public Hotel GetHotelById(string id);
    public IList<Hotel> GetAllHotels();
  }
}
