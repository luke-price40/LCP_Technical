using NUnit.Framework;

namespace UnitTests
{
    public abstract class BaseGiven<T>
    {
        protected T SUT { get; set; }

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
    }
}