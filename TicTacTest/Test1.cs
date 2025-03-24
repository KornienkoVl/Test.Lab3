namespace TicTac.Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Game game = new Game();
            Assert.IsTrue(game.MakeMove(1));
        }
    }
}
