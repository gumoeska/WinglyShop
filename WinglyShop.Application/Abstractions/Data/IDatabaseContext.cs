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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WinglyShop.Application.Abstractions.Messaging;

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

	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

	// Additional Props

	ChangeTracker ChangeTracker { get; }
	DatabaseFacade Database { get; }
	EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
	EntityEntry Attach(object entity);
	void AttachRange(params object[] entities);
	void AttachRange(IEnumerable<object> entities);
	EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
	EntityEntry Entry(object entity);
	bool Equals(object obj);
	EntityEntry Remove(object entity);
	EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
	void RemoveRange(IEnumerable<object> entities);
	void RemoveRange(params object[] entities);
	int SaveChanges(bool acceptAllChangesOnSuccess);
	int SaveChanges();
	Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
	DbSet<TEntity> Set<TEntity>() where TEntity : class;
	EntityEntry Update(object entity);
	EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
	void UpdateRange(params object[] entities);
	void UpdateRange(IEnumerable<object> entities);
}
