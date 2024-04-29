using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.User;

public class User : BaseEntity
{
	public User(
		int accountId,
		string name,
		string surname,
		string image)
	{
		AccountId = accountId;
		Name = name;
		Surname = surname;
		Image = image;
	}

	public int AccountId { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Image { get; set; }
}
