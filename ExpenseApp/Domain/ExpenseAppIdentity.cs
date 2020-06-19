﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApp.Domain
{
    public class ExpenseAppIdentity : IdentityUser

    {

        public string Gender { get; set; }

    }

}