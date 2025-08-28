using tarea_4.Models;

namespace tarea_4.Infrastructure.Data
{
  public class CityRepository : ICityRepository
  {
    private readonly List<City> _cities;

    public CityRepository()
    {
      _cities = new List<City>
      {
        new City
        {
          Id = "C001",
          Name = "Montevideo",
          Country = "Uruguay",
          Population = 1400000,
          Attractions = new List<string> { "Rambla de Montevideo", "Ciudad Vieja", "Teatro Solís" },
          TraditionalFoods = new List<string> { "Asado", "Chivito", "Dulce de leche" }
        },
        new City
        {
          Id = "C002",
          Name = "Buenos Aires",
          Country = "Argentina",
          Population = 3000000,
          Attractions = new List<string> { "Obelisco", "La Boca", "Teatro Colón" },
          TraditionalFoods = new List<string> { "Empanadas", "Milanesa", "Dulce de leche" }
        },
        new City
        {
          Id = "C003",
          Name = "Rio de Janeiro",
          Country = "Brasil",
          Population = 6700000,
          Attractions = new List<string> { "Cristo Redentor", "Pan de Azúcar", "Copacabana" },
          TraditionalFoods = new List<string> { "Feijoada", "Pão de queijo", "Acarajé" }
        }
      };
    }

    public City GetCityById(string id)
    {
      City? city = _cities.FirstOrDefault(c => c.Id == id);
      return city ?? throw new KeyNotFoundException($"City with ID {id} not found.");
    }

    public IList<City> GetAllCities()
    {
      return this._cities.ToList();
    }
  }
}


