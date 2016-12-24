
using NUnit.Framework;


namespace Courses.Test
{
    [TestFixture]
    public class FacadeTest
    {
        private IFacade facade;

        private interface ITestModel: IModel
        {

        }

        private class ModelStub : ITestModel
        {
            public bool IsLoaded { get; private set;}           

            public void Dispose()
            {
                IsLoaded = false;
            }

            public void Init(object data = null)
            {
                IsLoaded = true;
            }
        }

        [SetUp]
        public void SetUp()
        {
            facade = Facade.GetInstanse();
        }

        [Test]
        public void EditorTest()
        {
            ITestModel testModel = facade.GetModel<ITestModel>();
            Assert.AreEqual(testModel, null);

            facade.RegisterModel<ITestModel, ModelStub>();
            Assert.Catch( ()=> { facade.RegisterModel<ITestModel, ModelStub>(); });          
            testModel = facade.GetModel<ITestModel>();

            Assert.AreNotEqual(testModel, null);
            Assert.AreEqual(testModel.IsLoaded, true);

            facade.DisposeModel<ITestModel>();
            Assert.AreEqual(testModel.IsLoaded, false);

        }  
        
        [TearDown]
        public void TearDown()
        {
            facade = null;
            Facade.Reset();
        }
    }
}

