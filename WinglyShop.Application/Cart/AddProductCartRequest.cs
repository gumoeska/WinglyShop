using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinglyShop.Application.Cart;

public record AddProductCartRequest(int cartId, int productId, int quantity);