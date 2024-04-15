﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SharedLib.Auth

{
    public class IdentitySharedService : IIdentitySharedService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentitySharedService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        //public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
