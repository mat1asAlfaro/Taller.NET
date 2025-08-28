using tarea_4.Models;

namespace tarea_4.Infrastructure.Data
{
  public class BeachRepository : IBeachRepository
  {
    private readonly List<Beach> _beaches;

    public BeachRepository()
    {
      _beaches = new List<Beach>
      {
        new Beach
        {
          Id = "B001",
          Name = "Playa Paraíso",
          Location = "Punta del Este, Uruguay",
          Type = "Arena Blanca",
          Activities = new List<string> { "Surf", "Vóley de playa", "Snorkel" },
          Facilities = new List<string> { "Restaurantes", "Baños", "Estacionamiento" }
        },
        new Beach
        {
          Id = "B002",
          Name = "Playa Océano",
          Location = "La Paloma, Uruguay",
          Type = "Rocosa",
          Activities = new List<string> { "Pesca", "Senderismo", "Kayak" },
          Facilities = new List<string> { "Parqueo", "Kiosco", "Sombrillas" }
        },
        new Beach
        {
          Id = "B003",
          Name = "Playa Sol y Mar",
          Location = "José Ignacio, Uruguay",
          Type = "Arena Dorada",
          Activities = new List<string> { "Natación", "Paddleboard", "Relax" },
          Facilities = new List<string> { "Duchas", "Restaurantes", "Alquiler de sombrillas" }
        }
      };
    }

    public Beach GetBeachById(string id)
    {
      Beach? beach = _beaches.FirstOrDefault(b => b.Id == id);
      return beach ?? throw new KeyNotFoundException($"Beach with ID {id} not found.");
    }

    public IList<Beach> GetAllBeaches()
    {
      return this._beaches.ToList();
    }
  }
}


