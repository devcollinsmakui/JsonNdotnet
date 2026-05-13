
class Person : IEntity
{
    public string Id {get; set;} = string.Empty;
    public string Name {get; set; } = string.Empty;
    public int Age{get;set;}
    public Gender Gender {get; set;}
    public string[] Hobies {get; set;} = [];
    string IEntity.Id { get => Id.ToString();set;}
}