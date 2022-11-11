using System;
using System.Collections.Generic;
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
    public class ProductManager : IProductService
    {
        private IProductDao _productDao;
        private ICategoryDao _categoryDao;
        public ProductManager(IProductDao productDao, ICategoryDao categoryDao)
        {
            _productDao = productDao;
            _categoryDao = categoryDao;
        }
        /// <summary>
        /// /Returns the entire product list.
        /// </summary>
        /// <returns></returns>
        public IDataResult<IList<Product>> GetList()
        {
            return new SuccessDataResult<IList<Product>>(_productDao.GetList());
        }
        /// <summary>
        /// Returns the entire product list asynchronously.
        /// </summary>
        /// <returns>List<Product></returns>
        public async Task<IDataResult<IList<Product>>> GetListAsync()
        {
            var products = await _productDao.GetListAsync();
            return new SuccessDataResult<IList<Product>>(products);
        }
        /// <summary>
        /// Returns a product with the given id.
        /// </summary>
        /// <param name="productId">Product's ID.</param>
        /// <returns>A product</returns>
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDao.Get(p => p.Id == productId));
        }
        /// <summary>
        /// Returns a product with the given id asynchronously.
        /// </summary>
        /// <param name="productId">Product's ID.</param>
        /// <returns>A product</returns>
        public async Task<IDataResult<Product>> GetByIdAsync(int productId)
        {
            var product = await _productDao.GetAsync(p => p.Id == productId);
            return new SuccessDataResult<Product>(product);
        }


        public IDataResult<ProductDetailsDto> GetProductDetailsById(int productId)
        {
            var product = _productDao.Get(p => p.Id == productId);
            var productCategory = _categoryDao.Get(c => c.Id == product.CategoryId);
            var productDetailsDto = new ProductDetailsDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductPrice = product.UnitPrice,
                ProductCost = product.UnitCost,
                ProductQuantity = product.UnitCount,
            };

            if (productCategory != null)
            {
                productDetailsDto.CategoryId = productCategory.Id;
                productDetailsDto.CategoryName = productCategory.Name;
            }

            return new SuccessDataResult<ProductDetailsDto>(productDetailsDto);
        }

        public async Task<IDataResult<ProductDetailsDto>> GetProductDetailsByIdAsync(int productId)
        {
            var product = await _productDao.GetAsync(p => p.Id == productId);
            var productCategory = await _categoryDao.GetAsync(c => c.Id == product.CategoryId);
            var productDetailsDto = new ProductDetailsDto
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductPrice = product.UnitPrice,
                ProductCost = product.UnitCost,
                ProductQuantity = product.UnitCount,
            };

            if(productCategory != null)
            {
                productDetailsDto.CategoryId = productCategory.Id;
                productDetailsDto.CategoryName = productCategory.Name;
            }

            return new SuccessDataResult<ProductDetailsDto>(productDetailsDto);
            
        }

        public IDataResult<IList<ProductListDto>> GetProductListDto()
        {
            var productListDtos = new List<ProductListDto>();
            var productCategory = new Category();

            IList<Product> products =  _productDao.GetList();
            foreach (Product p in products)
            {
                productCategory = _categoryDao.Get(c => c.Id == p.CategoryId);
                productListDtos.Add(
                    new ProductListDto
                    {
                        ProductId = p.Id,
                        ProductName = p.Name,
                        ProductDescription = p.Description,
                        CategoryId = productCategory.Id,
                        CategoryName = productCategory.Name,
                        ProductPrice = p.UnitPrice,
                        ProductCost = p.UnitCost,
                        ProductQuantity = p.UnitCount,
                    }
                );
            }
            return new SuccessDataResult<IList<ProductListDto>>(productListDtos);
        }

        
        public async Task<IDataResult<IList<ProductListDto>>> GetProductListDtoAsync()
        {
            var productListDtos = new List<ProductListDto>();
            var productCategory = new Category();

            IList<Product> products = await _productDao.GetListAsync();
            foreach (Product p in products)
            {
                productCategory = await _categoryDao.GetAsync(c => c.Id == p.CategoryId);
                var productListDto = new ProductListDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductDescription = p.Description,
                    ProductPrice = p.UnitPrice,
                    ProductCost = p.UnitCost,
                    ProductQuantity = p.UnitCount,
                };
                if (productCategory != null)
                {
                    productListDto.CategoryId = productCategory.Id;
                    productListDto.CategoryName = productCategory.Name;
                }
                productListDtos.Add(productListDto);
            }
            return new SuccessDataResult<IList<ProductListDto>>(productListDtos);
        }

        public IResult Add(Product product)
        {
            _productDao.Add(product);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }
        public async Task<IResult> AddAsync(Product product)
        {
            await _productDao.AddAsync(product);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public IResult Update(Product product)
        {
            _productDao.Update(product);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }
        public async Task<IResult> UpdateAsync(Product product)
        {
            await _productDao.UpdateAsync(product);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public IResult Delete(Product product)
        {
            _productDao.Delete(product);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }
        public async Task<IResult> DeleteAsync(Product product)
        {
            await _productDao.DeleteAsync(product);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }
    }
}