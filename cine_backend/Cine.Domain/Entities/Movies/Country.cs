namespace Cine.Domain.Entities.Movies;
public class Country
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public List<Movie> Movies { get; private set; } = new List<Movie>();
    public Country(string name)
    {
        Name = name;
    }
    public Country(int id, string name)
    {
        Id = id;
        Name = name;
    }

}