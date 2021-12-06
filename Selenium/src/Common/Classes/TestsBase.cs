using System;

namespace Common.Classes
{
    public abstract class TestsBase : IDisposable
    {
        protected TestsBase()
        {
            Driver.StartBrowser();
        }

        public void Dispose() => Driver.StopBrowser();
    }
}
