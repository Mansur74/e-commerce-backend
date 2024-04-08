using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICartService
    {
        public Result Create(CartDto cartDto, int userId, int productId);
        public Result Update(CartDto cartDto, int cartId);
        public Result Delete(int cartId);
        public DataResult<ICollection<CartDto>> GetAllCarts();

    }
}
