﻿using BuberDiner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Domain.Menu.Events
{
   public record MenuCreated(Menu Menu):IDomainEvents;
   
}
