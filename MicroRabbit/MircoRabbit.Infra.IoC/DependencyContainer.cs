﻿using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MircoRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterSevices(IServiceCollection services)
        {

            //domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //Domain Banking Commans
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //application layer
            services.AddTransient<IAccountService, AccountService>();

            //Data Layer
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();

        }
    }
}
