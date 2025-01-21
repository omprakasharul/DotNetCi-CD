using BAL.Common;
using BAL.Interface;
using BOL;
using BOL.Request;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Classes
{
    public class InventoryBAL : IInventoryBAL
    {
        private readonly IInventoryDAL _inventoryDAL;

        public InventoryBAL(IInventoryDAL inventoryDAL)
        {
            _inventoryDAL = inventoryDAL;
        }

        public async Task<ListResult<List<Inventory>>> GetAll(int pageNo, int pageSize, string sku, int itemId, int categoryId)
        {
            try
            {
                var resultModel = new ListResult<List<Inventory>>();
                var result = await _inventoryDAL.GetAll(pageNo, pageSize, sku, itemId, categoryId);

                var inventoryres = new InventoryRes();
                foreach (Inventory inventory in result.Item1)
                {
                    inventoryres.Id = inventory.Id;

                }

                if (result != null)
                {
                    resultModel.Data = result.Item1;
                    resultModel.TotalCount = result.Item2;
                    resultModel.Message = Resource.List;
                    resultModel.Success = true;
                }
                else
                {
                    resultModel.Success = false;
                    resultModel.Message = "Inventory Records is not retrieved";
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Inventory>> Create(Inventory inventory)
        {
            var inventoryModel = new Result<Inventory>();
            try
            {
                var inventoryDetail = await _inventoryDAL.GetByExpression(x => x.ItemId == inventory.ItemId
                && x.CategoryId == inventory.CategoryId);
                if (inventoryDetail == null)
                {
                    inventory.IsActive = true;
                    inventory.IsDelete = false;
                    inventory.CreatedDate = DateTime.UtcNow;
                    inventory.UpdatedDate = DateTime.UtcNow;
                    inventory.IsActive = true;
                    inventory.IsDelete = false;

                    var result = await _inventoryDAL.Create(inventory);

                    inventoryModel.Data = result;
                    inventoryModel.Success = true;
                    inventoryModel.Message = Resource.Create;
                }
                else
                {
                    inventoryModel.Success = false;
                    inventoryModel.Message = "ItemName with same Category already exists";
                    inventoryModel.Data = null;
                }
                return inventoryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Inventory>> Get(int inventoryId)
        {
            try
            {
                var userModel = new Result<Inventory>();
                var user = await _inventoryDAL.GetByExpression(x => x.Id == inventoryId && x.IsActive == true);
                if (user != null)
                {
                    userModel.Data = user;
                    userModel.Success = true;
                    userModel.Message = Resource.Get;
                }
                else
                {
                    userModel.Success = false;
                    userModel.Message = "Id is not valid";
                    userModel.Data = null;
                }
                return userModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Inventory>> Update(Inventory inventory)
        {
            try
            {
                var userModel = new Result<Inventory>();
                var inventoryDetail = await _inventoryDAL.GetByExpression(x => x.Id == inventory.Id && x.IsActive == true);
                if (inventoryDetail != null)
                {
                    inventoryDetail.ItemId = inventory.ItemId;
                    inventoryDetail.SKU = inventory.SKU;
                    inventoryDetail.CategoryId = inventory.CategoryId;
                    inventoryDetail.Description = inventory.Description;
                    inventoryDetail.SupplierId = inventory.SupplierId;
                    inventoryDetail.Price = inventory.Price;
                    inventoryDetail.Quantity = inventory.Quantity;
                    inventoryDetail.ReorderLevel = inventory.ReorderLevel;
                    inventoryDetail.IsActive = inventory.IsActive;
                    inventoryDetail.IsDelete = inventory.IsDelete;
                    inventoryDetail.UpdatedBy = inventory.UpdatedBy;
                    inventoryDetail.UpdatedDate = DateTime.UtcNow;

                    var userObj = await _inventoryDAL.Update(inventoryDetail);

                    userModel.Success = true;
                    userModel.Data = userObj;
                    userModel.Message = Resource.Update;
                }
                else
                {
                    userModel.Success = false;
                    userModel.Message = "Record is not retrieved check ID";
                    userModel.Data = null;
                }
                return userModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<string>> Delete(int inventoryId)
        {
            try
            {
                var resultModel = new Result<string>();
                var deletedUser = await _inventoryDAL.GetByExpression(x => x.Id == inventoryId && x.IsActive == true);
                if (deletedUser != null)
                {
                    deletedUser.IsActive = false;
                    deletedUser.IsDelete = true;
                    var result = await _inventoryDAL.Update(deletedUser);
                    resultModel.Message = Resource.Delete;
                    resultModel.Success = true;
                }
                else
                {
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
