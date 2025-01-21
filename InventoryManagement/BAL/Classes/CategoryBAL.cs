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
    public class CategoryBAL : ICategoryBAL
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryBAL(ICategoryDAL categoryDAL) {
            _categoryDAL = categoryDAL;
        }

        public async Task<Result<List<Category>>> GetAll()
        {
            try
            {
                var resultModel = new Result<List<Category>>();
                resultModel.Data = await _categoryDAL.GetAll();
                resultModel.Success = true;
                resultModel.Message = Resource.List;
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Category>> Create(Category category)
        {
            try
            {
                var resultModel = new Result<Category>();
                var categoryModel = await _categoryDAL.GetByExpression(x => x.Name == category.Name);
                if (categoryModel == null)
                {
                    category.CreatedDate = DateTime.Now;
                    category.IsActive = true;
                    category.IsDelete = false;
                    resultModel.Data = await _categoryDAL.Create(category);
                    resultModel.Success = true;
                    resultModel.Message = Resource.Create;
                }
                else
                {
                    resultModel.Data = categoryModel;
                    resultModel.Success = false;
                    resultModel.Message = "Category already exsits";
                }
                return resultModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Category>> Update(Category category)
        {
            try
            {
                var resultModel = new Result<Category>();
                var categoryModel = await _categoryDAL.GetByExpression(x => x.Id == category.Id && x.IsActive == true);
                if(categoryModel != null)
                {
                    categoryModel.Name = category.Name;
                    categoryModel.UpdatedDate = DateTime.Now;
                    categoryModel.UpdatedBy = category.UpdatedBy;
                    categoryModel.IsActive = category.IsActive;
                    categoryModel.IsDelete = category.IsDelete;
                    resultModel.Data = await _categoryDAL.Update(category);
                    resultModel.Success = true;
                    resultModel.Message = Resource.Create;
                }
                else
                {
                    resultModel.Data = categoryModel;
                    resultModel.Success = false;
                    resultModel.Message = "Category is not exsits check ID";
                }
                return resultModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<Category>> Get(int categoryId)
        {
            try
            {
                var categoryModel = new Result<Category>();
                var category = await _categoryDAL.GetByExpression(x => x.Id == categoryId && x.IsActive == true);
                if (categoryModel != null)
                {
                    categoryModel.Data = category;
                    categoryModel.Success = true;
                    categoryModel.Message = Resource.Get;
                }
                else
                {
                    categoryModel.Success = false;
                    categoryModel.Message = "Id is not valid";
                    categoryModel.Data = null;
                }
                return categoryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<string>> Delete(int categoryId)
        {
            try
            {
                var resultModel = new Result<string>();
                var deletedCategory = await _categoryDAL.GetByExpression(x => x.Id == categoryId && x.IsActive == true);
                if (deletedCategory != null)
                {
                    deletedCategory.IsActive = false;
                    deletedCategory.IsDelete = true;
                    var result = await _categoryDAL.Update(deletedCategory);
                    resultModel.Data = "Category Deleted";
                    resultModel.Message = Resource.Delete;
                    resultModel.Success = true;
                }
                else
                {
                    resultModel.Data = "Category is not Deleted";
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

        public async Task<ListResult<List<Items>>> getItemList()
        {
            try
            {
                var categoryModel = new ListResult<List<Items>>();
                var items = await _categoryDAL.getItemsList();
                if (categoryModel != null)
                {
                    categoryModel.Data = items;
                    categoryModel.Success = true;
                    categoryModel.Message = Resource.Get;
                }
                else
                {
                    categoryModel.Success = false;
                    categoryModel.Message = "Id is not valid";
                    categoryModel.Data = null;
                }
                return categoryModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
