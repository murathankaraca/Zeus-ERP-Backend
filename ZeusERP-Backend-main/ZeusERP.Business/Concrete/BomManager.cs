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
    public class BomManager : IBomService
    {
        private IBomDao _bomDao;
        private IProductDao _productDao;
        public BomManager(IBomDao bomDao, IProductDao productDao)
        {
            _bomDao = bomDao;
            _productDao = productDao;
        }
        public IDataResult<BillOfMaterials> GetById(int id)
        {
            return new SuccessDataResult<BillOfMaterials>(_bomDao.Get(c => c.Id == id));
        }

        public async Task<IDataResult<BillOfMaterials>> GetByIdAsync(int id)
        {
            var component = await _bomDao.GetAsync(c => c.Id == id);
            return new SuccessDataResult<BillOfMaterials>(component);
        }

        public IDataResult<IList<BillOfMaterials>> GetList()
        {
            return new SuccessDataResult<IList<BillOfMaterials>>(_bomDao.GetList());
        }

        public async Task<IDataResult<IList<BillOfMaterials>>> GetListAsync()
        {
            var components = await _bomDao.GetListAsync();
            return new SuccessDataResult<IList<BillOfMaterials>>(components);
        }

        public IResult Add(BillOfMaterials bom)
        {
            _bomDao.Add(bom);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public async Task<IResult> AddAsync(BillOfMaterials bom)
        {
            await _bomDao.AddAsync(bom);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public IResult Update(BillOfMaterials bom)
        {
            _bomDao.Update(bom);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public async Task<IResult> UpdateAsync(BillOfMaterials bom)
        {
            await _bomDao.UpdateAsync(bom);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public IResult Delete(BillOfMaterials bom)
        {
            _bomDao.Delete(bom);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public async Task<IResult> DeleteAsync(BillOfMaterials bom)
        {
            await _bomDao.DeleteAsync(bom);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public IDataResult<BomDetailsDto> GetBomDetailsDtoById(int bomId)
        {
            var bom = _bomDao.Get(b => b.Id == bomId);
            var productOfBom = _productDao.Get(p => p.Id == bom.ProductId);

            var bomDetailsDto = new BomDetailsDto
            {
                BomId = bom.Id,
                ProductId = bom.ProductId,
                ProductName = productOfBom.Name,
                BomReference = bom.Reference,
                BomType = bom.BoMType,
                Quantity = bom.Quantity
            };

            return new SuccessDataResult<BomDetailsDto>(bomDetailsDto);
        }

        public async Task<IDataResult<BomDetailsDto>> GetBomDetailsDtoByIdAsync(int bomId)
        {
            var bom = await _bomDao.GetAsync(b => b.Id == bomId);
            var productOfBom = await _productDao.GetAsync(p => p.Id == bom.ProductId);

            var bomDetailsDto = new BomDetailsDto
            {
                BomId = bom.Id,
                ProductId = bom.ProductId,
                ProductName = productOfBom.Name,
                BomReference = bom.Reference,
                BomType = bom.BoMType,
                Quantity = bom.Quantity
            };

            return new SuccessDataResult<BomDetailsDto>(bomDetailsDto);
        }

        public IDataResult<IList<BomListDto>> GetBomListDto()
        {
            var boms = _bomDao.GetList();
            List<Product> products = _productDao.GetList() as List<Product>;
            List<BomListDto> bomListDtos = new List<BomListDto>();

            foreach(BillOfMaterials bom in boms)
            {
                BomListDto bomListDtoToAdd = new BomListDto
                {
                    BomId = bom.Id,
                    ProductId = bom.ProductId,
                    ProductName = products.Find(p => p.Id == bom.ProductId).Name,
                    BomReference = bom.Reference,
                    BomType = bom.BoMType,
                    Quantity = bom.Quantity
                };

                bomListDtos.Add(bomListDtoToAdd);
            }

            return new SuccessDataResult<IList<BomListDto>>(bomListDtos);
        }

        public async Task<IDataResult<IList<BomListDto>>> GetBomListDtoAsync()
        {
            var boms = await _bomDao.GetListAsync();
            List<Product> products = await _productDao.GetListAsync() as List<Product>;
            List<BomListDto> bomListDtos = new List<BomListDto>();

            foreach (BillOfMaterials bom in boms)
            {
                BomListDto bomListDtoToAdd = new BomListDto
                {
                    BomId = bom.Id,
                    ProductId = bom.ProductId,
                    ProductName = products.Find(p => p.Id == bom.ProductId).Name,
                    BomReference = bom.Reference,
                    BomType = bom.BoMType,
                    Quantity = bom.Quantity
                };

                bomListDtos.Add(bomListDtoToAdd);
            }

            return new SuccessDataResult<IList<BomListDto>>(bomListDtos);
        }
    }
}
