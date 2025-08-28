using tarea_4.Models;

namespace tarea_4.Infrastructure.Data
{
  public class HotelRepository : IHotelRepository
  {
    private readonly List<Hotel> _hotels;

    public HotelRepository()
    {
      _hotels = new List<Hotel>
      {
        new Hotel
        {
          Id = "H001",
          Name = "Hotel Central",
          Location = "Montevideo",
          Category = 4,
          PricePerNight = 120.5f,
          Amenities = new List<string> { "WiFi", "Piscina", "Desayuno incluido", "Gimnasio" }
        },
        new Hotel
        {
          Id = "H002",
          Name = "Playa Resort",
          Location = "Punta del Este",
          Category = 5,
          PricePerNight = 250f,
          Amenities = new List<string> { "WiFi", "Spa", "Vista al mar", "All Inclusive", "Piscina infinita" }
        },
        new Hotel
        {
          Id = "H003",
          Name = "Eco Lodge",
          Location = "Colonia",
          Category = 3,
          PricePerNight = 85.75f,
          Amenities = new List<string> { "WiFi", "Estacionamiento gratis", "Excursiones guiadas" }
        }
      };
    }

    public Hotel GetHotelById(string id)
    {
      Hotel? hotel = _hotels.FirstOrDefault(h => h.Id == id);
      return hotel ?? throw new KeyNotFoundException($"Hotel with ID {id} not found.");
    }

    public IList<Hotel> GetAllHotels()
    {
      return this._hotels.ToList();
    }

  };
}
