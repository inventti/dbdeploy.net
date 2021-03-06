namespace Net.Sf.Dbdeploy.Scripts
{
    using System.Collections.Generic;
    using System.Linq;

    using Net.Sf.Dbdeploy.Exceptions;

    using NUnit.Framework;

    [TestFixture]
    public class ChangeScriptRepositoryTest
    {
        [Test]
        [Ignore]
        public void TestGivenASetOfChangeScriptsReturnsThemCorrectly()
        {
            ChangeScript one = new ChangeScript("Scripts", 1);
            ChangeScript two = new ChangeScript("Scripts", 2);
            ChangeScript three = new ChangeScript("Scripts", 3);
            ChangeScript four = new ChangeScript("Scripts", 4);

            ChangeScript[] scripts = {three, two, four, one};

            ChangeScriptRepository repository = new ChangeScriptRepository(new List<ChangeScript>(scripts));

            List<ChangeScript> list = repository.GetAvailableChangeScripts().ToList();

            Assert.AreEqual(4, list.Count);
            Assert.AreSame(one, list[0]);
            Assert.AreSame(two, list[1]);
            Assert.AreSame(three, list[2]);
            Assert.AreSame(four, list[3]);
        }

        [Test]
        public void TestThrowsWhenConstructedWithAChangeScriptListThatHasDuplicates()
        {
            var two = new ChangeScript("Alpha", 2);
            var three = new ChangeScript("Alpha", 3);
            var four = new ChangeScript("Beta", 3);
            var anotherTwo = new ChangeScript("Alpha", 2);

            try
            {
                var scripts = new[] { three, four, two, anotherTwo };
                // ReSharper disable ObjectCreationAsStatement
                new ChangeScriptRepository(new List<ChangeScript>(scripts));
                // ReSharper restore ObjectCreationAsStatement
                Assert.Fail("expected exception");
            }
            catch (DuplicateChangeScriptException ex)
            {
                Assert.AreEqual("There is more than one change script with key 'Alpha/2'.", ex.Message);
            }
        }

        [Test]
        public void TestChangeScriptsMayBeNumberedFromZero()
        {
            ChangeScript zero = new ChangeScript("Scripts", 0);
            ChangeScript four = new ChangeScript("Scripts", 4);


            ChangeScript[] scripts = new ChangeScript[] {zero, four};
            ChangeScriptRepository repository =
                new ChangeScriptRepository(new List<ChangeScript>(scripts));

            List<ChangeScript> list = repository.GetAvailableChangeScripts().ToList();

            Assert.AreEqual(2, list.Count);
            Assert.AreSame(zero, list[0]);
            Assert.AreSame(four, list[1]);
        }
    }
}