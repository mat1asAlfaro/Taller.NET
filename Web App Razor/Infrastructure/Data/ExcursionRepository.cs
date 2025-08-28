using tarea_4.Models;

namespace tarea_4.Infrastructure.Data
{
  public class ExcursionRepository : IExcursionRepository
  {
    private readonly List<Excursion> _excursions;

    public ExcursionRepository()
    {
      _excursions = new List<Excursion>
      {
        new Excursion
        {
          Id = "E001",
          Name = "Caminata por el Cerro",
          Location = "Montevideo",
          PricePerPerson = 35.5f,
          Includes = new List<string> { "Guía", "Botella de agua", "Snacks" },
          Difficulty = "Media"
        },
        new Excursion
        {
          Id = "E002",
          Name = "Tour en Kayak",
          Location = "Punta del Este",
          PricePerPerson = 60.0f,
          Includes = new List<string> { "Kayak", "Chaleco salvavidas", "Instructor" },
          Difficulty = "Alta"
        },
        new Excursion
        {
          Id = "E003",
          Name = "Visita a Bodega",
          Location = "Colonia",
          PricePerPerson = 45.0f,
          Includes = new List<string> { "Degustación de vinos", "Recorrido guiado", "Aperitivos" },
          Difficulty = "Baja"
        }
      };
    }

    public Excursion GetExcursionById(string id)
    {
      Excursion? excursion = _excursions.FirstOrDefault(e => e.Id == id);
      return excursion ?? throw new KeyNotFoundException($"Excursion with ID {id} not found.");
    }

    public IList<Excursion> GetAllExcursions()
    {
      return this._excursions.ToList();
    }
  }
}


