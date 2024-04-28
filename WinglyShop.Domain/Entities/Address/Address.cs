using WinglyShop.Domain.Common;

namespace WinglyShop.Domain.Entities.Address;

public class Address : BaseEntity
{
	public int UserId { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Country { get; set; }
	public string PostalCode { get; set; }
}
