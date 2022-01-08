using Application.MappingProfiles;
using AutoMapper;
using NUnit.Framework;

namespace UnitTests
{
    public abstract class BaseGiven<T>
    {
        protected T SUT { get; set; }

        protected IMapper MockMapper;

        [SetUp]
        public void Setup()
        {
            Given();
            When();
        }

        [TearDown]
        public void TearDown()
        {
        }

        public virtual void Given()
        {
        }

        public virtual void When()
        {
        }

        protected void CreateMockMapper()
        {
            var configurationProvider = new MapperConfiguration(
                config => { config.AddProfile<ClientProfiles>(); });

            MockMapper = configurationProvider.CreateMapper();
        }
    }
}