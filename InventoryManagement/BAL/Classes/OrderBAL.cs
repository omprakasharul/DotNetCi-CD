using Azure;
using BAL.Common;
using BAL.Interface;
using BOL;
using BOL.Request;
using DAL.Classes;
using DAL.DBContext;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Classes
{
    public class OrderBAL : IOrderBAL
    {
        private readonly IOrderDAl _iOrderDAl;
        private readonly DALDbContext _dALDbContext;

        public OrderBAL(IOrderDAl orderDAl, DALDbContext dALDbContext)
        {
            _iOrderDAl = orderDAl;
            _dALDbContext = dALDbContext;
        }
        public async Task<ListResult<List<Order>>> GetAll(int pageNo, int pageSize, string name)
        {
            try
            {
                var resultModel = new ListResult<List<Order>>();
                var result = await _iOrderDAl.GetAll(pageNo, pageSize, name);
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
                    resultModel.Message = "Orders Records is not retrieved";
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Order>> Create(OrderReq orderDto)
        {
            var orderModel = new Result<Order>();
            try
            {
                var order = new Order
                {
                    CustomerName = orderDto.CustomerName,
                    OrderDate = DateTime.Now,
                    Status = "Pending",
                    TotalAmount = orderDto.OrderItems.Sum(oi => oi.Quantity * oi.Price),
                    OrderItems = orderDto.OrderItems.Select(oi => new Order_Item
                    {
                        ItemId = oi.ItemId,
                        InventoryId = oi.InventoryId,
                        Quantity = oi.Quantity,
                        Price = oi.Price,
                        IsActive = true,
                        IsDelete = false,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        CreatedBy = orderDto.CreatedBy,
                        UpdatedBy = orderDto.UpdatedBy
            }).ToList()
                };
                if (order != null)
                {
                    order.IsActive = true;
                    order.IsDelete = false;
                    order.CreatedDate = DateTime.UtcNow;
                    order.UpdatedDate = DateTime.UtcNow;
                    order.CreatedBy = orderDto.CreatedBy;
                    order.UpdatedBy = orderDto.UpdatedBy;

                    var result = await _iOrderDAl.Create(order);

                    orderModel.Data = result;
                    orderModel.Success = true;
                    orderModel.Message = Resource.Create;
                }
                else
                {
                    orderModel.Success = false;
                    orderModel.Message = "Order is null";
                    orderModel.Data = null;
                }
                return orderModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Order>> Get(int orderId)
        {
            try
            {
                var orderModel = new Result<Order>();
                var user = await _iOrderDAl.GetByExpression(orderId);
                if (user != null)
                {
                    orderModel.Data = user;
                    orderModel.Success = true;
                    orderModel.Message = Resource.Get;
                }
                else
                {
                    orderModel.Success = false;
                    orderModel.Message = "Id is not valid";
                    orderModel.Data = null;
                }
                return orderModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Order>> Update(OrderUpdateDto orderUpdateDto, int id)
        {
            try
            {
                var userModel = new Result<Order>();
                var order = await _iOrderDAl.GetByExpression(id);

                if (order != null)
                {
                    order.CustomerName = orderUpdateDto.CustomerName;
                    order.Status = orderUpdateDto.Status;
                    order.TotalAmount = orderUpdateDto.OrderItems.Sum(oi => oi.Quantity * oi.Price);
                    order.IsActive = orderUpdateDto.IsActive;
                    order.IsDelete = orderUpdateDto.IsDelete;
                    order.UpdatedBy = orderUpdateDto.updatedBy;
                    order.UpdatedDate = DateTime.UtcNow;

                    // Remove existing order items
                    _dALDbContext.orderItems.RemoveRange(order.OrderItems);

                    // Add updated order items
                    order.OrderItems = orderUpdateDto.OrderItems.Select(oi => new Order_Item
                    {
                        InventoryId = oi.InventoryId,
                        Quantity = oi.Quantity,
                        Price = oi.Price
                    }).ToList();

                    var userObj = await _iOrderDAl.Update(order);

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

        public async Task<Result<string>> Delete(int id)
        {
            try
            {
                var resultModel = new Result<string>();
                var deletedUser = await _iOrderDAl.GetByExpression(id);
                if (deletedUser != null)
                {
                    deletedUser.IsActive = false;
                    deletedUser.IsDelete = true;
                    var result = await _iOrderDAl.Update(deletedUser);
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
