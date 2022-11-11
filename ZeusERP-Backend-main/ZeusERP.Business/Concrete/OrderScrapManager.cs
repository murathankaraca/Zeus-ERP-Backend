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
    public class OrderScrapManager : IOrderScrapService
    {
        private IOrderScrapDao _scrapDao;
        private ILocationDao _locationDao;
        private IProductDao _productDao;
        public OrderScrapManager(IOrderScrapDao scrapDao, ILocationDao locationDao, IProductDao productDao)
        {
            _scrapDao = scrapDao;
            _locationDao = locationDao;
            _productDao = productDao;
        }
        public IDataResult<IList<Scrap>> GetList()
        {
            return new SuccessDataResult<IList<Scrap>>(_scrapDao.GetList());
        }

        public async Task<IDataResult<IList<Scrap>>> GetListAsync()
        {
            var orders = await _scrapDao.GetListAsync();
            return new SuccessDataResult<IList<Scrap>>(orders);
        }

        public IDataResult<Scrap> GetById(int id)
        {
            return new SuccessDataResult<Scrap>(_scrapDao.Get(s => s.Id == id));
        }

        public async Task<IDataResult<Scrap>> GetByIdAsync(int id)
        {
            var order = await _scrapDao.GetAsync(s => s.Id == id);
            return new SuccessDataResult<Scrap>(order);
        }

        public IResult Add(Scrap scrap)
        {
            _scrapDao.Add(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderAdded);
        }

        public async Task<IResult> AddAsync(Scrap scrap)
        {
            await _scrapDao.AddAsync(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderAdded);
        }

        public IResult Update(Scrap scrap)
        {
            _scrapDao.Update(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderAdded);
        }

        public async Task<IResult> UpdateAsync(Scrap scrap)
        {
            await _scrapDao.UpdateAsync(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderUpdated);
        }

        public IResult Delete(Scrap scrap)
        {
            _scrapDao.Delete(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Scrap scrap)
        {
            await _scrapDao.DeleteAsync(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderDeleted);
        }

        public IDataResult<ScrapDetailsDto> GetScrapDetailsDtoById(int scrapId)
        {
            var scrap = _scrapDao.Get(s => s.Id == scrapId);
            var locSource = _locationDao.Get(l => l.Id == scrap.SourceLocationId);
            var locScrap = _locationDao.Get(l => l.Id == scrap.ScrapLocationId);
            var productToScrap = _productDao.Get(p => p.Id == scrap.ProductId);

            var scrapDetailsDto = new ScrapDetailsDto
            {
                ScrapId = scrap.Id,
                ProductId = productToScrap.Id,
                ProductName = productToScrap.Name,
                OrderReference = scrap.Reference,
                OrderDescription = scrap.Description,
                ScheduledDate = scrap.ScheduledDate,
                CompletedDate = scrap.CompletedDate,
                Quantity = scrap.Quantity,
                ScrapLocationId = locScrap.Id,
                ScrapLocationName = locScrap.Name,
                SourceLocationId = locSource.Id,
                SourceLocationName = locSource.Name,
                ScrapStatus = scrap.Status,
            };
            return new SuccessDataResult<ScrapDetailsDto>(scrapDetailsDto);
        }

        public async Task<IDataResult<ScrapDetailsDto>> GetScrapDetailsDtoByIdAsync(int scrapId)
        {
            var scrap = await _scrapDao.GetAsync(s => s.Id == scrapId);
            var locSource = await _locationDao.GetAsync(l => l.Id == scrap.SourceLocationId);
            var locScrap = await _locationDao.GetAsync(l => l.Id == scrap.ScrapLocationId);
            var productToScrap = await _productDao.GetAsync(p => p.Id == scrap.ProductId);

            var scrapDetailsDto = new ScrapDetailsDto
            {
                ScrapId = scrap.Id,
                ProductId = productToScrap.Id,
                ProductName = productToScrap.Name,
                OrderReference = scrap.Reference,
                OrderDescription = scrap.Description,
                ScheduledDate = scrap.ScheduledDate,
                CompletedDate = scrap.CompletedDate,
                Quantity = scrap.Quantity,
                ScrapLocationId = locScrap.Id,
                ScrapLocationName = locScrap.Name,
                SourceLocationId = locSource.Id,
                SourceLocationName = locSource.Name,
                ScrapStatus = scrap.Status,
            };
            return new SuccessDataResult<ScrapDetailsDto>(scrapDetailsDto);
        }

        public IDataResult<IList<ScrapListDto>> GetScrapListDto()
        {
            var scraps = _scrapDao.GetList();
            var scrapListDtos = new List<ScrapListDto>();
            foreach(var scrap in scraps)
            {
                var scrapListDto = new ScrapListDto
                {
                    ScrapId = scrap.Id,
                    OrderReference = scrap.Reference,
                    OrderDescription = scrap.Description,
                    ScheduledDate = scrap.ScheduledDate,
                    CompletedDate = scrap.CompletedDate,
                    Quantity = scrap.Quantity,
                    ScrapStatus = scrap.Status,
                };

                if (scrap.ProductId != null)
                {
                    var productToScrap = _productDao.Get(p => p.Id == scrap.ProductId);
                    scrapListDto.ProductId = productToScrap.Id;
                    scrapListDto.ProductName = productToScrap.Name;
                }
                if (scrap.ScrapLocationId != null)
                {
                    var locScrap = _locationDao.Get(l => l.Id == scrap.ScrapLocationId);
                    scrapListDto.ScrapLocationId = locScrap.Id;
                    scrapListDto.ScrapLocationName = locScrap.Name;
                }
                if (scrap.SourceLocationId != null)
                {
                    var locSource = _locationDao.Get(l => l.Id == scrap.SourceLocationId);
                    scrapListDto.SourceLocationId = locSource.Id;
                    scrapListDto.SourceLocationName = locSource.Name;
                }
                scrapListDtos.Add(scrapListDto);
            }
            
            return new SuccessDataResult<IList<ScrapListDto>>(scrapListDtos);
        }

        public async Task<IDataResult<IList<ScrapListDto>>> GetScrapListDtoAsync()
        {
            var scrapListDtos = new List<ScrapListDto>();
            var scraps = await _scrapDao.GetListAsync();
            foreach (var scrap in scraps)
            {
                var scrapListDto = new ScrapListDto
                {
                    ScrapId = scrap.Id,
                    OrderReference = scrap.Reference,
                    OrderDescription = scrap.Description,
                    ScheduledDate = scrap.ScheduledDate,
                    CompletedDate = scrap.CompletedDate,
                    Quantity = scrap.Quantity,
                    ScrapStatus = scrap.Status,
                };

                if (scrap.ProductId != null)
                {
                    var productToScrap = await _productDao.GetAsync(p => p.Id == scrap.ProductId);
                    scrapListDto.ProductId = productToScrap.Id;
                    scrapListDto.ProductName = productToScrap.Name;
                }
                if (scrap.ScrapLocationId != null)
                {
                    var locScrap = await _locationDao.GetAsync(l => l.Id == scrap.ScrapLocationId);
                    scrapListDto.ScrapLocationId = locScrap.Id;
                    scrapListDto.ScrapLocationName = locScrap.Name;
                }
                if (scrap.SourceLocationId != null)
                {
                    var locSource = await _locationDao.GetAsync(l => l.Id == scrap.SourceLocationId);
                    scrapListDto.SourceLocationId = locSource.Id;
                    scrapListDto.SourceLocationName = locSource.Name;
                }
                scrapListDtos.Add(scrapListDto);
            }

            return new SuccessDataResult<IList<ScrapListDto>>(scrapListDtos);
        }
    }
}
