﻿using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using MSF.Endpoints.Web.Extentions;
using MSF.Utilities.Services.Users;

namespace MSF.Endpoints.Web.Services
{
    public class WebUserInfoService : IUserInfoService
    {
        private readonly HttpContext _httpContext;
        private const string AccessList = "";

        public WebUserInfoService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null || httpContextAccessor.HttpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string GetUserAgent() => _httpContext.Request.Headers["User-Agent"];
        public string GetUserIp() => _httpContext.Connection.RemoteIpAddress.ToString();
        public Guid UserId() => Guid.Parse(_httpContext.User?.GetClaim(ClaimTypes.NameIdentifier));
        public string GetUsername() => _httpContext.User?.GetClaim(ClaimTypes.Name);
        public string GetFirstName() => _httpContext.User?.GetClaim(ClaimTypes.GivenName);
        public string GetLastName() => _httpContext.User?.GetClaim(ClaimTypes.Surname);
        public bool IsCurrentUser(string userId)
        {
            return string.Equals(UserId().ToString(), userId, StringComparison.OrdinalIgnoreCase);
        }

        public virtual bool HasAccess(string accessKey)
        {
            var result = false;

            if (!string.IsNullOrWhiteSpace(accessKey))
            {
                var accessList = _httpContext.User?.GetClaim(AccessList)?.Split(',').ToList() ?? new List<string>();
                result = accessList.Any(key => string.Equals(key, accessKey, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }
    }
}
