using Test.Repositories;

namespace Test
{
    public class UnitOfWork
    {
        private readonly TestDBContext _dBContext;

        public UnitOfWork(TestDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void SaveChanges()
        {
            _dBContext.SaveChanges();
        }

        private TestModelRepository? testModelRepository;
        public TestModelRepository TestModelRepository
        {
            get
            {

                if (testModelRepository == null)
                {
                    testModelRepository = new TestModelRepository(_dBContext);
                }
                return testModelRepository;
            }
        }

    }
}
