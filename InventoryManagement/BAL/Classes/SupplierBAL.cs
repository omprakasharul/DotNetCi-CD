using BAL.Common;
using BAL.Interface;
using BOL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Classes
{
    public class SupplierBAL : ISupplierBAL
    {
        private readonly ISupplierDAL _supplierDAL;
        public SupplierBAL(ISupplierDAL supplierDAL)
        {
            _supplierDAL = supplierDAL;
        }

        public async Task<Result<List<Supplier>>> GetAll()
        {
            try
            {
                var resultModel = new Result<List<Supplier>>();
                resultModel.Data = await _supplierDAL.GetAll();
                resultModel.Success = true;
                resultModel.Message = Resource.List;
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Supplier>> Create(Supplier supplier)
        {
            try
            {
                var resultModel = new Result<Supplier>();
                var supplierModel = await _supplierDAL.GetByExpression(x => x.Name == supplier.Name);
                if (supplierModel == null)
                {
                    supplier.CreatedDate = DateTime.Now;
                    supplier.IsActive = true;
                    supplier.IsDelete = false;
                    resultModel.Data = await _supplierDAL.Create(supplier);
                    resultModel.Success = true;
                    resultModel.Message = Resource.Create;
                }
                else
                {
                    resultModel.Data = supplier;
                    resultModel.Success = false;
                    resultModel.Message = "Supplier already exsits";
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Supplier>> Update(Supplier supplier)
        {
            try
            {
                var resultModel = new Result<Supplier>();
                var supplierModel = await _supplierDAL.GetByExpression(x => x.Id == supplier.Id && x.IsActive == true);
                if (supplierModel != null)
                {
                    supplierModel.Name = supplier.Name;
                    supplierModel.Notes = supplier.Notes;
                    supplierModel.Address = supplierModel.Address;
                    supplierModel.Phone = supplierModel.Phone;
                    supplierModel.Email = supplierModel.Email;
                    supplierModel.ContactInfo = supplierModel.ContactInfo;
                    supplierModel.UpdatedDate = DateTime.Now;
                    supplierModel.UpdatedBy = supplier.UpdatedBy;
                    supplierModel.IsActive = supplier.IsActive;
                    supplierModel.IsDelete = supplier.IsDelete;
                    resultModel.Data = await _supplierDAL.Update(supplierModel);
                    resultModel.Success = true;
                    resultModel.Message = Resource.Create;
                }
                else
                {
                    resultModel.Data = supplierModel;
                    resultModel.Success = false;
                    resultModel.Message = "Supplier is not exsits check ID";
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Supplier>> Get(int supplierId)
        {
            try
            {
                var supplierModel = new Result<Supplier>();
                var category = await _supplierDAL.GetByExpression(x => x.Id == supplierId && x.IsActive == true);
                if (supplierModel != null)
                {
                    supplierModel.Data = category;
                    supplierModel.Success = true;
                    supplierModel.Message = Resource.Get;
                }
                else
                {
                    supplierModel.Success = false;
                    supplierModel.Message = "Id is not valid";
                    supplierModel.Data = null;
                }
                return supplierModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<string>> Delete(int supplierId)
        {
            try
            {
                var resultModel = new Result<string>();
                var deletedSupplier = await _supplierDAL.GetByExpression(x => x.Id == supplierId && x.IsActive == true);
                if (deletedSupplier != null)
                {
                    deletedSupplier.IsActive = false;
                    deletedSupplier.IsDelete = true;
                    var result = await _supplierDAL.Update(deletedSupplier);
                    resultModel.Data = "Supplier Deleted";
                    resultModel.Message = Resource.Delete;
                    resultModel.Success = true;
                }
                else
                {
                    resultModel.Data = "Supplier is not Deleted";
                    resultModel.Message = "Id is not valid";
                    resultModel.Success = false;
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
