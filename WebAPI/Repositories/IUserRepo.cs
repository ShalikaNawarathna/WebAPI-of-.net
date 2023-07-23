using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IUserRepo
    {
        Task<User> Get(string id);
         List<User> AllTodos();
         Task<User> Login(string email, string password);
        Task<User> CreateUser(User user);
    }
}
