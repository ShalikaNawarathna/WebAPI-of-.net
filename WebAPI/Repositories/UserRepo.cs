using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    
    public class UserRepo :  IUserRepo
    {
      
        private readonly IMongoCollection<User> _collection;
        private readonly IOptions<DataBaseSettings> _dbsettings;
    public UserRepo(IMongoClient mongoClient, IDataBaseSettings bookStoreDatabaseSettings, IOptions<DataBaseSettings> dbsettings)
    {
            
        var database = mongoClient.GetDatabase(bookStoreDatabaseSettings.DatabaseName);
        _collection = database.GetCollection<User>(bookStoreDatabaseSettings.CollectionName);
            _dbsettings = dbsettings;
    }
    
        public List<User> AllTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(string id)
        {
            var getUser =  await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
            if (getUser == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                return getUser;
            }


        } 

        public async Task<User> Login(string email, string password)

        {
           // ObjectContext context = new ObjectContext(_dbsettings);
            //ObjectContext context = new ObjectContext(email, password);

            if (string.IsNullOrWhiteSpace(email)) {
                throw new ArgumentNullException(nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(email));
            }
            
            var filter = Builders<User>.Filter.Eq("email", email.ToLower());
            var userList = await _collection.Find(filter).Limit(1).ToListAsync();

            if (userList.Count == 1)
            {
                var loginUser = userList[0];
                if (loginUser.Password == password)
                {
           
                    return loginUser;
                }
                else
                {
                    //throw new InvalidCastException("Invalid  Password");
                    throw new InvalidOperationException("Invalid Password");
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid Credetilas");
            }
        }

        public async Task<User> CreateUser(User user)
        {

            var existingUser = await _collection.Find(u=>u.Email == user.Email).FirstOrDefaultAsync();
            if (existingUser == null)
            {
                await _collection.InsertOneAsync(user);

                return user;

            }

            // 
            // Console.WriteLine(user);
            existingUser.Email = "exits";
            return existingUser;
        }

        private User Ok(User user)
        {
            throw new NotImplementedException();
        }
    }
}
