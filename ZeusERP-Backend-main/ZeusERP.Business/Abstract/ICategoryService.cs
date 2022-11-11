using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int Id);
        Task<IDataResult<Category>> GetByIdAsync(int Id);
        IDataResult<Category> GetByName(string name);
        Task<IDataResult<Category>> GetByNameAsync(string name);
        IDataResult<IList<Category>> GetList();
        Task<IDataResult<IList<Category>>> GetListAsync();
        IResult Add(Category category);
        Task<IResult> AddAsync(Category category);
        IResult Update(Category category);
        Task<IResult> UpdateAsync(Category category);
        IResult Delete(Category category);
        Task<IResult> DeleteAsync(Category category);

        // DTOs

        IDataResult<CategoryDetailsDto> GetCategoryDetailsById(int categoryId);
        Task<IDataResult<CategoryDetailsDto>> GetCategoryDetailsByIdAsync(int categoryId);
        IDataResult<IList<CategoryListDto>> GetCategoryList();
        Task<IDataResult<IList<CategoryListDto>>> GetCategoryListAsync();
    }
}
