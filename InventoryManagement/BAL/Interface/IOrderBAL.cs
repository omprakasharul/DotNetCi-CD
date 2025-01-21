using BOL;
using BOL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IOrderBAL
    {
        Task<ListResult<List<Order>>> GetAll(int pageNo, int pageSize, string name);
        Task<Result<Order>> Create(OrderReq orderDto);
        Task<Result<Order>> Get(int orderId);
        Task<Result<Order>> Update(OrderUpdateDto orderUpdateDto, int id);
        Task<Result<string>> Delete(int id);
    }
}
