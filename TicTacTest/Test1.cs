namespace TicTac.Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethodMakeMove()
        {
            Game game = new Game();

            Assert.IsTrue(game.MakeMove(1,1));

            //проверка изменения матрицы после хода
            Assert.AreEqual(game.map[1,1],1);
        }
    }
}
