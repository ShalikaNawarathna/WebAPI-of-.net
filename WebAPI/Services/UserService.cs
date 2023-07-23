using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class UserService :  IUserService
    {
       
        private readonly IUserRepo _userRepository;
        public UserService(
            
            IUserRepo userRepository
            )
        {
            
            _userRepository = userRepository;
        }
        /*
        public List<User> Get()
        {
            return _collection.Find(user => true).ToList();
        }

        
        public User Create(User user)
        { //Get method eka call karal data ganna
            user.UpdatedDate = DateTime.Now;  //UTC
            user.UpdatedBy = "admin"; 
            user.Status = MyDataStatus.InProgress;
            _collection.InsertOne(user);
            return user;
        }
        //return the list of all users 
      public void Remove(string id)
        {
             _collection.DeleteOne(user => user.Id == id);
        }

        public void update(string id, User user)
        {
            _collection.ReplaceOne(user => user.Id == id,user);
        }

        */

        public async Task<User> Get(string id)
        {
            return await _userRepository.Get( id );


        }
        public  async Task<User> Login(Login user)
        {
            // User loginUser = _collection.Find(login => login.Email == email && login.Password == password).FirstOrDefault();
            //return loginUser;
            
            return await  _userRepository.Login(user.Email, user.Password);


        }
        public async Task<User> createUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }

    }
}
