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
    public class BomComponentManager : IBomComponentService
    {
        private IBomDao _bomDao;
        private  IBomComponentDao _bomComponentDao;
        private IProductDao _productDao;
        public BomComponentManager(IBomDao bomDao, IBomComponentDao bomComponentDao, IProductDao productDao)
        {
            _bomDao = bomDao;
            _bomComponentDao = bomComponentDao;
            _productDao = productDao;
        }
        public IDataResult<BillOfMaterialsComponent> GetById(int id)
        {
            return new SuccessDataResult<BillOfMaterialsComponent>(_bomComponentDao.Get(c => c.Id == id));
        }

        public async Task<IDataResult<BillOfMaterialsComponent>> GetByIdAsync(int id)
        {
            var component = await _bomComponentDao.GetAsync(c => c.Id == id);
            return new SuccessDataResult<BillOfMaterialsComponent>(component);
        }

        public IDataResult<IList<BillOfMaterialsComponent>> GetListByOrderId(int orderId)
        {
            var bom = _bomDao.Get(bom => bom.Id == orderId);
            var bomComps = _bomComponentDao.GetList(bomComp => bomComp.BomId == bom.Id);

            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(bomComps);
        }

        public async Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListByOrderIdAsync(int orderId)
        {
            var bom = await _bomDao.GetAsync(bom => bom.Id == orderId);
            var bomComps = await _bomComponentDao.GetListAsync(bomComp => bomComp.BomId == bom.Id);

            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(bomComps);
        }

        public IDataResult<IList<BillOfMaterialsComponent>> GetList()
        {
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(_bomComponentDao.GetList());
        }

        public async Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListAsync()
        {
            var components = await _bomComponentDao.GetListAsync();
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(components);
        }

        public IDataResult<IList<BillOfMaterialsComponent>> GetListByBomId(int bomId)
        {
            var components = _bomComponentDao.GetList(c => c.BomId == bomId);
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(components);
        }

        public async Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListByBomIdAsync(int bomId)
        {
            var components = await _bomComponentDao.GetListAsync(c => c.BomId == bomId);
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(components);
        }

        public IResult Add(BillOfMaterialsComponent bomComponent)
        {
            _bomComponentDao.Add(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public async Task<IResult> AddAsync(BillOfMaterialsComponent bomComponent)
        {
            await _bomComponentDao.AddAsync(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public IResult Update(BillOfMaterialsComponent bomComponent)
        {
            _bomComponentDao.Update(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public async Task<IResult> UpdateAsync(BillOfMaterialsComponent bomComponent)
        {
            await _bomComponentDao.UpdateAsync(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public IResult Delete(BillOfMaterialsComponent bomComponent)
        {
            _bomComponentDao.Delete(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public async Task<IResult> DeleteAsync(BillOfMaterialsComponent bomComponent)
        {
            await _bomComponentDao.DeleteAsync(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public IDataResult<BomComponentDetailsDto> GetBomComponentDetailsDtoById(int bomComponentId)
        {
            var bomComp = _bomComponentDao.Get(comp => comp.Id == bomComponentId);
            var productInComp = _productDao.Get(p => p.Id == bomComp.ProductId);
            var bom = _bomDao.Get(comp => comp.Id == bomComp.BomId);
            var bomComponentDetailsDto = new BomComponentDetailsDto
            {
                BomComponentId = bomComp.Id,
                BomId = bomComp.BomId,
                BomReference = bom.Reference,
                ProductId = bomComp.ProductId,
                ProductName = productInComp.Name,
            };

            return new SuccessDataResult<BomComponentDetailsDto>(bomComponentDetailsDto);
        }

        public async Task<IDataResult<BomComponentDetailsDto>> GetBomComponentDetailsDtoByIdAsync(int bomComponentId)
        {
            var bomComp = await _bomComponentDao.GetAsync(comp => comp.Id == bomComponentId);
            var productInComp = await _productDao.GetAsync(p => p.Id == bomComp.ProductId);
            var bom = await _bomDao.GetAsync(comp => comp.Id == bomComp.BomId);
            var bomComponentDetailsDto = new BomComponentDetailsDto
            {
                BomComponentId = bomComp.Id,
                BomId = bomComp.BomId,
                BomReference = bom.Reference,
                ProductId = bomComp.ProductId,
                ProductName = productInComp.Name,
            };

            return new SuccessDataResult<BomComponentDetailsDto>(bomComponentDetailsDto);
        }

        public IDataResult<IList<BomComponentDetailsDto>> GetBomComponentDetailsDtoByOrderId(int orderId)
        {
            var bomCompDetailsDtos = new List<BomComponentDetailsDto>();
            var bom = _bomDao.Get(b => b.Id == orderId);
            var bomComps = _bomComponentDao.GetList(comp => comp.BomId == bom.Id);
            var products = _productDao.GetList() as List<Product>;
            foreach (BillOfMaterialsComponent bomComp in bomComps)
            {
                var product = products.Find(p => p.Id == bomComp.ProductId);
                var bomCompDetailsDto = new BomComponentDetailsDto
                {
                    BomId = bom.Id,
                    BomReference = bom.Reference,
                    BomComponentId = bomComp.Id,
                    ProductId = product.Id,
                    ProductName = product.Name
                };
                bomCompDetailsDtos.Add(bomCompDetailsDto);
            }
            return new SuccessDataResult<IList<BomComponentDetailsDto>>(bomCompDetailsDtos);
        }

        public async Task<IDataResult<IList<BomComponentDetailsDto>>> GetBomComponentDetailsDtoByOrderIdAsync(int orderId)
        {
            List<BomComponentDetailsDto> bomCompDetailsDtos = new List<BomComponentDetailsDto>();
            var bom = await _bomDao.GetAsync(b => b.Id == orderId);
            var bomComps = await _bomComponentDao.GetListAsync(comp => comp.BomId == bom.Id);
            var products = await _productDao.GetListAsync() as  List<Product>;
            foreach(BillOfMaterialsComponent bomComp in bomComps)
            {
                var product = products.Find(p => p.Id == bomComp.ProductId);
                var bomCompDetailsDto = new BomComponentDetailsDto
                {
                    BomId = bom.Id,
                    BomReference = bom.Reference,
                    BomComponentId = bomComp.Id,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = bomComp.Quantity
                };
                bomCompDetailsDtos.Add(bomCompDetailsDto);
            }
            return new SuccessDataResult<IList<BomComponentDetailsDto>>(bomCompDetailsDtos);
        }
    }
}
