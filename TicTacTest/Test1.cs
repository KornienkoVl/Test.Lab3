﻿namespace TicTac.Test
{
    [TestClass]
    public sealed class TestMove
    {
        [TestMethod]
        public void TestMethodMakeMove()
        {
            Game game = new Game();

            Assert.IsTrue(game.MakeMove(1,1));

            //проверка изменения матрицы после хода
            Assert.AreEqual(game.map[1,1],1);
        }

        [TestMethod]
        public void TestMethodMakeMoveXY()
        {
            Game game = new Game();

            Assert.IsFalse(game.MakeMove(-1, 1));
            Assert.IsFalse(game.MakeMove(-1, -1));
            Assert.IsFalse(game.MakeMove(1, -1));
            Assert.IsFalse(game.MakeMove(3, 1));
            Assert.IsFalse(game.MakeMove(2, 3));
            Assert.IsFalse(game.MakeMove(3, 3));
            Assert.IsFalse(game.MakeMove(-5, 6));
            Assert.IsFalse(game.MakeMove(6, -5));

            Assert.IsTrue(game.MakeMove(0, 0));
            Assert.IsTrue(game.MakeMove(1, 1));
            Assert.IsTrue(game.MakeMove(2, 2));
            Assert.IsTrue(game.MakeMove(0, 2));
            Assert.IsTrue(game.MakeMove(2, 0));
        }

        [TestMethod]
        public void TestMethodMakeMoveEmpty()
        {
            Game game = new Game();

            Assert.IsTrue(game.MakeMove(1, 1));
            Assert.IsFalse(game.MakeMove(1, 1));
        }
    }
    [TestClass]
    public sealed class TestChangePlayer
    {
        [TestMethod]
        public void TestMethodChangePlayer()
        {
            Game game = new Game();

            Assert.AreEqual(game.player, 1);
            game.ChangePlayer();
            Assert.AreEqual(game.player, -1);
            game.ChangePlayer();
            Assert.AreEqual(game.player, 1);
        }
    }

}
