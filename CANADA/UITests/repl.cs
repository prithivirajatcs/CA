using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace CANADA.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class repl
    {
        IApp app;
        Platform platform;
        public repl(Platform platform)
        {
            this.platform = platform;
        }
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void repldisplay()
        {
            app.Repl();
        }
    }
}
