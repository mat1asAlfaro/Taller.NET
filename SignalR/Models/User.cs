namespace tarea3a.Models
{
  public class User
  {
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public String Password { get; set; }

    public User(String first_name, String last_name, String email, String password)
    {
      this.FirstName = first_name;
      this.LastName = last_name;
      this.Email = email;
      this.Password = password;
    }

    public Boolean ValidUser()
    {
      return true;
    }

    public Boolean NeedVerification()
    {
      return true;
    }
  }
}