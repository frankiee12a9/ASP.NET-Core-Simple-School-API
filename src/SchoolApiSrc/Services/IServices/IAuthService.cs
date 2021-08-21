using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolApiSrc.Models;

namespace SchoolApiSrc.Services.IServices
{
    public interface IAuthService
    {
        Task<IEnumerable<AppLoginInfo>> GetAll();
        Task<AppLoginInfo> GetOne(string userName);
        Task Register(AppLoginInfo entity);
        Task<bool> Login(string userName, string password);
        Task<bool> IsAccountExists(string userName);
        void Delete(int id);
        Task SaveAsync();
    }
}