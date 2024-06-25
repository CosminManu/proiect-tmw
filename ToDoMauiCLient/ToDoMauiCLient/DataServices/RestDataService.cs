using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoMauiCLient.Models;

namespace ToDoMauiCLient.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _serializerOptions;

        public RestDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5209" : "https://localhost:7209";
            _url = $"{_baseAddress}/api";

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }
        public Task AddToDoAsync(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> GetAllToDosAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
