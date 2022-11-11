using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDao _categoryDao;
        private IProductDao _productDao;
        public CategoryManager(ICategoryDao categoryDao, IProductDao productDao)
        {
            _categoryDao = categoryDao;
            _productDao = productDao;
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDao.Get(c => c.Id == categoryId));
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int categoryId)
        {
            var category = await _categoryDao.GetAsync(c => c.Id == categoryId);
            return new SuccessDataResult<Category>(category);
        }

        public IDataResult<Category> GetByName(string categoryName)
        {
            return new SuccessDataResult<Category>(_categoryDao.Get(c => c.Name == categoryName));
        }

        public async Task<IDataResult<Category>> GetByNameAsync(string categoryName)
        {
            var category = await _categoryDao.GetAsync(c => c.Name == categoryName);
            return new SuccessDataResult<Category>(category);
        }

        public IDataResult<CategoryDetailsDto> GetCategoryDetailsById(int categoryId)
        {
            var category = _categoryDao.Get(c => c.Id == categoryId);
            var subcategory = _categoryDao.Get(c => c.ParentCategoryId == category.Id);

            var categoryDetailsDto = new CategoryDetailsDto
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                CategoryDescription = category.Description,
            };
            if (subcategory != null)
            {
                categoryDetailsDto.ParentCategoryId = subcategory.Id;
                categoryDetailsDto.ParentCategoryName = subcategory.Name;
            }
            return new SuccessDataResult<CategoryDetailsDto>(categoryDetailsDto);
        }

        public IDataResult<IList<Category>> GetList()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDao.GetList());
        }
        public async Task<IDataResult<IList<Category>>> GetListAsync()
        {
            var categories = await _categoryDao.GetListAsync();
            return new SuccessDataResult<IList<Category>>(categories);
        }

        public IResult Add(Category category)
        {
            _categoryDao.Add(category);
            return new SuccessResult(true, ResultMessages.CategoryAdded);
        }

        public async Task<IResult> AddAsync(Category category)
        {
            await _categoryDao.AddAsync(category);
            return new SuccessResult(true, ResultMessages.CategoryAdded);
        }

        public IResult Update(Category category)
        {
            _categoryDao.Update(category);
            return new SuccessResult(true, ResultMessages.CategoryUpdated);
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            await _categoryDao.UpdateAsync(category);
            return new SuccessResult(true, ResultMessages.CategoryUpdated);
        }

        public IResult Delete(Category category)
        {
            _categoryDao.Delete(category);
            return new SuccessResult(true, ResultMessages.CategoryDeleted);
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
            var productsOfCategory = await _productDao.GetListAsync();

            bool hasDependencies = productsOfCategory.Any((product) =>
            {
                return product.CategoryId == category.Id;
            });

            if (hasDependencies)
            {
                return new SuccessResult(false, ResultMessages.CategoryNotDeleted);
            }
            await _categoryDao.DeleteAsync(category);
            return new SuccessResult(true, ResultMessages.CategoryDeleted);
        }

        public async Task<IDataResult<CategoryDetailsDto>> GetCategoryDetailsByIdAsync(int categoryId)
        {
            var category = await _categoryDao.GetAsync(c => c.Id == categoryId);
            var subcategory = await _categoryDao.GetAsync(c => c.Id == category.ParentCategoryId);

            var categoryDetailsDto = new CategoryDetailsDto
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                CategoryDescription = category.Description,
            };
            if(subcategory != null)
            {
                categoryDetailsDto.ParentCategoryId = subcategory.Id;
                categoryDetailsDto.ParentCategoryName = subcategory.Name;
            }
            return new SuccessDataResult<CategoryDetailsDto>(categoryDetailsDto);
        }

        public IDataResult<IList<CategoryListDto>> GetCategoryList()
        {
            var categoryListDtos = new List<CategoryListDto>();
            var category = new Category();

            IList<Category> categories = _categoryDao.GetList();
            foreach (Category c in categories)
            {
                categoryListDtos.Add(new CategoryListDto { CategoryId = c.Id, CategoryName = c.Name, CategoryDescription = c.Description });
            }
            return new SuccessDataResult<List<CategoryListDto>>(categoryListDtos);
        }

        public async Task<IDataResult<IList<CategoryListDto>>> GetCategoryListAsync()
        {
            var categoryListDtos = new List<CategoryListDto>();

            IList<Category> categories = await _categoryDao.GetListAsync();
            foreach (Category c in categories)
            {
                var categoryListDto = new CategoryListDto
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    CategoryDescription = c.Description,
                };
                // Get Parent Category's data if it exists.
                if (c.ParentCategoryId != null)
                {
                    var cat = await _categoryDao.GetAsync(p => p.Id == c.ParentCategoryId);
                    categoryListDto.ParentCategoryId = cat.Id;
                    categoryListDto.ParentCategoryName = cat.Name;
                }
                categoryListDtos.Add(categoryListDto);
            }
            return new SuccessDataResult<List<CategoryListDto>>(categoryListDtos);
        }
    }
}
