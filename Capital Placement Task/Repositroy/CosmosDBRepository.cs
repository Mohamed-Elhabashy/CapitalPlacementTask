using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Capital_Placement_Task.Repository
{
    public class CosmosDBRepository<T> where T : class
    {
        private readonly Container _container;

        public CosmosDBRepository(Container container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public async Task AddAsync(T entity)
        {
            await _container.CreateItemAsync(entity, new PartitionKey(entity.Id.ToString()));
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var items = new List<T>();

            var resultSet = _container.GetItemQueryIterator<T>(query);

            while (resultSet.HasMoreResults)
            {
                var response = await resultSet.ReadNextAsync();
                items.AddRange(response);
            }

            return items;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity == null)
            {
                return null;
            }

            var response = await _container.UpsertItemAsync(entity, new PartitionKey(id));
            return response.Resource;
        }
    }
}
