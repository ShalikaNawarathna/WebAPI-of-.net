namespace WebAPI.Models
{
    public interface IDataBaseSettings
    {
        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; } 
    }
}
