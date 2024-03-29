﻿using AspnetcoreMicroservices.Events;
using AutoMapper;
using Ordering.Application.Features.Commands.Orders.CheckoutOrder;


namespace Ordering.API.Mapper
{
    public class OrderingProfile : Profile
	{
		public OrderingProfile()
		{
			CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
		}
	}
}
