﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoApi.Models.Api;

namespace TodoApi.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> GetUser(ClaimsPrincipal user);
        Task<User> Register(RegisterData data, ModelStateDictionary modelState);
    }
}
