using System;

namespace InjectTooMany
{

    interface ICustomsService {}

    interface ITaxService {}

    interface IDeliveryService {}

    interface IShippingService {}

    interface IStockService {}
    class OrderServiceTooMany
    {
        public OrderServiceTooMany(
            ICustomsService customsService,
            ITaxService taxService,
            IDeliveryService deliveryService,
            IShippingService shippingService,
            IStockService stockService
        )
        {
            
        }
    }

    interface IOrderPreProcess {}
    class OrderPreProcess  : IOrderPreProcess
    { 
        public OrderPreProcess(
            ITaxService taxService,
            IStockService stockService

        )
        {}
    }

    interface IOrderShippingService{}
    class OrderShippingService
    {
        public OrderShippingService(
            ICustomsService customesService,
            IDeliveryService deliveryService,
            IShippingService shippingService
        ){}
    }

    class OrderService
    {
        public OrderService(
            IOrderPreProcess orderPreProcessService,
            IOrderShippingService orderShippingService
        )
        {}
    }
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
