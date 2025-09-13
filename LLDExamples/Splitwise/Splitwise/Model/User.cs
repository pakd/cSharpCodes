namespace Splitwise;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }


    public User(int id, string name, string email)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
    }
}