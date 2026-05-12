using System.Text.Json;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        IPeoplRepository repository = new PeopleRepository();

        Person person1 = new Person
        {
            Id = "one",
            Name = "Asenath Nyabuto",
            Age = 19,
            Gender = Gender.Female,
            Hobies = ["cooking", "adventure"]
        };
        Person person2 = new Person
        {
            Id = "two",
            Name = "Collins Makui",
            Age = 25,
            Gender = Gender.Female,
            Hobies = ["music", "art"]
        };

        await repository.Save(person1);

    }
}
