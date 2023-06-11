using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Repositories
{
    public class TestModelRepository
    {
        private readonly DbContext _dbContext;

        public TestModelRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbSet<TestModel> Set => _dbContext.Set<TestModel>();
        protected IQueryable<TestModel> Table => Set;
        protected IQueryable<TestModel> TableAsNoTracking => Set.AsNoTracking();

        public TestModel? GetById(int id)
        {
            return Table.SingleOrDefault(x => x.Id == id);
        }

        public void Add(TestModel entity)
        {
            Set.Add(entity);
        }

        public void Update(TestModel entity)
        {
            Set.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity is not null)
                Delete(entity);
        }
        private void Delete(TestModel entity)
        {
            Set.Remove(entity);
        }

        public List<TestModel> GetAll()
        {
            return TableAsNoTracking.ToList();
        }
    }
}
