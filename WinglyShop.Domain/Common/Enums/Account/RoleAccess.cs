using System.ComponentModel;

namespace WinglyShop.Domain.Common.Enums.Account;

public enum RoleAccess
{
	[Description("Customer")]
	Customer = 0,

	[Description("Premium Customer")]
	PremiumCustomer = 1,

	[Description("Attendant")]
	Attendant = 2,

	[Description("Support")]
	Support = 3,

	[Description("Technical Support")]
	TechnicalSupport = 4,

	[Description("Manager")]
	Manager = 5,

	[Description("General Manager")]
	GeneralManager = 6,

	[Description("Developer")]
	Developer = 7,

	// Master Access
	[Description("Admin")]
	Admin = 100
}
