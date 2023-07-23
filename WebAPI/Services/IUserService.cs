using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserService
    {/*
        public List<User> Get();
        public User Get(string id);
        public User Create(User user);
        public void Remove(string id);
        public void update(string id, User user);*/
        Task<User> Get(string id);
        Task<User> Login(Login user);

        Task<User> createUser(User user);
    }
}
