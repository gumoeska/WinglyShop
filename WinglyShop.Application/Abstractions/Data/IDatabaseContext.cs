using Microsoft.EntityFrameworkCore;
using WinglyShop.Domain.Entities.Addresses;
using WinglyShop.Domain.Entities.CartDetails;
using WinglyShop.Domain.Entities.Carts;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Domain.Entities.OrderDetails;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Domain.Entities.Roles;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Domain.Entities.Orders;

namespace WinglyShop.Application.Abstractions.Data;

public interface IDatabaseContext
{
	DbSet<User> Users { get; set; }
	DbSet<Address> Addresses { get; set; }
	DbSet<Cart> Carts { get; set; }
	DbSet<CartDetail> CartDetails { get; set; }
	DbSet<Category> Categories { get; set; }
	DbSet<Order> Orders { get; set; }
	DbSet<OrderDetail> OrderDetails { get; set; }
	DbSet<Product> Products { get; set; }
	DbSet<Role> Roles { get; set; }
}
