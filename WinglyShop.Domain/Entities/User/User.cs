using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.User;

public class User : BaseEntity
{
    public User()
    {
    }

    public User(
		int idRole,
		string login,
		string password,
		string name,
		string surname,
		string image)
	{
		IdRole = idRole;
		Login = login;
		Password = password;
		Name = name;
		Surname = surname;
		Image = image;
	}

	public int IdRole { get; set; }

	public string Login { get; set; }
	public string Password { get; set; }
	public string Email { get; set; }

	public string Name { get; set; }
	public string Surname { get; set; }
	public string Image { get; set; }
	public string Phone { get; set; }
}
