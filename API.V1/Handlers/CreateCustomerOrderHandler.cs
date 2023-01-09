﻿using API.V1.Commands;
using API.V1.Responses;
using MediatR;

namespace API.V1.Handlers
{
    public class CreateCustomerOrderHandler : IRequestHandler<CreateCustomerOrderCommand, OrderResponse>
    {
        public Task<OrderResponse> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}