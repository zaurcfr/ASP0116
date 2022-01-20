using ASP0116.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP0116.FakeDB.Repositories.Carts.Abstract
{
    public interface ICartRepository
    {
        List<Cart> GetAll();
        Cart Add(Cart cart);
    }
}
