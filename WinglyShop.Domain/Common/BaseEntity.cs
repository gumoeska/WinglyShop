using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinglyShop.Domain.Common.Interfaces;

namespace WinglyShop.Domain.Common;

public class BaseEntity : IEntity
{
	public Guid Id { get; set; }
	public bool IsActive { get; set; }
}
