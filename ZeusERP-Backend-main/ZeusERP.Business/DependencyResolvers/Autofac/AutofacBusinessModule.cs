using Autofac;

using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Concrete;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.DataAccess.Concrete;

namespace ZeusERP.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EfProductDao>().As<IProductDao>();
            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<EfCategoryDao>().As<ICategoryDao>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            builder.RegisterType<EfLocationDao>().As<ILocationDao>();
            builder.RegisterType<LocationManager>().As<ILocationService>();

            builder.RegisterType<EfWarehouseDao>().As<IWarehouseDao>();
            builder.RegisterType<WarehouseManager>().As<IWarehouseService>();

            builder.RegisterType<EfContactDao>().As<IContactDao>();
            builder.RegisterType<ContactManager>().As<IContactService>();

            builder.RegisterType<EfOrderScrapDao>().As<IOrderScrapDao>();
            builder.RegisterType<OrderScrapManager>().As<IOrderScrapService>();

            builder.RegisterType<EfOrderDeliveryDao>().As<IOrderDeliveryDao>();
            builder.RegisterType<OrderDeliveryManager>().As<IOrderDeliveryService>();

            builder.RegisterType<EfOrderManufacturingDao>().As<IOrderManufacturingDao>();
            builder.RegisterType<OrderManufacturingManager>().As<IOrderManufacturingService>();

            builder.RegisterType<EfOrderReplenishmentDao>().As<IOrderReplenishmentDao>();
            builder.RegisterType<OrderReplenishmentManager>().As<IOrderReplenishmentService>();

            builder.RegisterType<EfBomDao>().As<IBomDao>();
            builder.RegisterType<BomManager>().As<IBomService>();

            builder.RegisterType<EfBomComponentDao>().As<IBomComponentDao>();
            builder.RegisterType<BomComponentManager>().As<IBomComponentService>();

            builder.RegisterType<EfOrderScrapDao>().As<IOrderScrapDao>();
            builder.RegisterType<OrderScrapManager>().As<IOrderScrapService>();

            builder.RegisterType<EfOrderTransferDao>().As<IOrderTransferDao>();
            builder.RegisterType<OrderTransferManager>().As<IOrderTransferService>();

            builder.RegisterType<EfOrderUnbuildDao>().As<IOrderUnbuildDao>();
            builder.RegisterType<OrderUnbuildManager>().As<IOrderUnbuildService>();

            builder.RegisterType<EfAddressDao>().As<IAddressDao>();
            builder.RegisterType<AddressManager>().As<IAddressService>();

        }
    }
}
