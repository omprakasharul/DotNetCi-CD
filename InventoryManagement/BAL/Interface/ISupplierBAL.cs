using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface ISupplierBAL
    {
        Task<Result<List<Supplier>>> GetAll();
        Task<Result<Supplier>> Create(Supplier supplier);
        Task<Result<Supplier>> Update(Supplier supplier);
        Task<Result<Supplier>> Get(int supplierId);
        Task<Result<string>> Delete(int supplierId);
    }
}
