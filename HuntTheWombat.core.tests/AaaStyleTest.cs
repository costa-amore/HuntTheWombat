using System;

namespace HuntTheWombat.core.tests
{
    /// <summary>
    /// AAA style tests use a single test class to setup a specific situation (arrange).  
    /// Each test method verifies a specific outcome to verify after triggering the behavior (act).  
    /// 
    /// The test class name describes the 'setup and trigger' ususally in the form of 'When<<SituationIsTriggered>>...'
    /// The test method names describe the outcome usually in the form of '<<ValidatableProperty>>ShouldBe_...'
    /// </summary>
    public class AaaStyleTest:IDisposable
    {
        public AaaStyleTest()
        {
            Arrange();
            Act();
        }

        protected virtual void Arrange() { }
        protected virtual void Act() { }

        public virtual void Dispose() { }
    }
}
