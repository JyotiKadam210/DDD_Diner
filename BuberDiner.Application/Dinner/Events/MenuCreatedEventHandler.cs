using BuberDiner.Domain.Menu.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Application.Dinner.Events
{
    public class MenuCreatedEventHandler : INotificationHandler<MenuCreated>
    {
        public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
