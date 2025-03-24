namespace TicTac.Test
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

        [TestMethod]
        public void TestMethodMakeMoveChangePlayer()
        {
            Game game = new Game();

            game.MakeMove(0, 0);
            game.MakeMove(0, 1);
            game.MakeMove(0, 2);

            Assert.AreEqual(game.map[0, 0], 1);
            Assert.AreEqual(game.map[0, 1], -1);
            Assert.AreEqual(game.map[0, 2], 1);
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

    [TestClass]
    public sealed class TestCheckWin
    {
        [TestMethod]
        public void TestMethodCheckWinHorizon()
        {
            Game game = new Game();

            Assert.AreEqual(game.checkWin(), 0);

            game.map[0, 0] = 1;
            game.map[0, 1] = 1;
            game.map[0, 2] = 1;

            Assert.AreEqual(game.checkWin(), 1);

            game.map[0, 0] = 0;
            game.map[0, 1] = 0;
            game.map[0, 2] = 0;

            game.map[2, 0] = -1;
            game.map[2, 1] = -1;
            game.map[2, 2] = -1;

            Assert.AreEqual(game.checkWin(), -1);
        }

        [TestMethod]
        public void TestMethodCheckWinVertical()
        {
            Game game = new Game();

            Assert.AreEqual(game.checkWin(), 0);

            game.map[0, 0] = 1;
            game.map[1, 0] = 1;
            game.map[2, 0] = 1;

            Assert.AreEqual(game.checkWin(), 1);

            game.map[0, 0] = 0;
            game.map[1, 0] = 0;
            game.map[2, 0] = 0;

            game.map[0, 2] = -1;
            game.map[1, 2] = -1;
            game.map[2, 2] = -1;

            Assert.AreEqual(game.checkWin(), -1);
        }

        [TestMethod]
        public void TestMethodCheckWinDiagonal()
        {
            Game game = new Game();

            Assert.AreEqual(game.checkWin(), 0);

            game.map[0, 0] = 1;
            game.map[1, 1] = 1;
            game.map[2, 2] = 1;

            Assert.AreEqual(game.checkWin(), 1);

            game.map[0, 0] = 0;
            game.map[1, 1] = 0;
            game.map[2, 2] = 0;

            game.map[0, 2] = -1;
            game.map[1, 1] = -1;
            game.map[2, 0] = -1;

            Assert.AreEqual(game.checkWin(), -1);
        }
    }

    [TestClass]
    public sealed class TestCheckDraw
    {
        [TestMethod]
        public void TestMethodCheckDraw()
        {
            Game game = new Game();

            Assert.IsFalse(game.checkDraw());

            game.MakeMove(0, 0);
            game.MakeMove(0, 1);
            game.MakeMove(0, 2);

            Assert.IsFalse(game.checkDraw());

            game.MakeMove(1, 0);
            game.MakeMove(1, 1);
            game.MakeMove(1, 2);

            Assert.IsFalse(game.checkDraw());

            game.MakeMove(2, 0);
            game.MakeMove(2, 1);

            Assert.IsFalse(game.checkDraw());

            game.MakeMove(2, 2);

            Assert.IsTrue(game.checkDraw());

        }
    }

    [TestClass]
    public sealed class TestClear
    {
        [TestMethod]
        public void TestMethodClear()
        {
            Game game = new Game();

            game.MakeMove(0, 0);
            game.MakeMove(2, 1);
            game.MakeMove(1, 2);

            game.Clear();

            Assert.AreEqual(game.map[0, 0], 0);
            Assert.AreEqual(game.map[2, 1], 0);
            Assert.AreEqual(game.map[1, 2], 0);

            Assert.AreEqual(game.player, 1);
        }
    }

    [TestClass]
    public sealed class TestPlay
    {
        [TestMethod]
        public void TestMethodPlayWin()
        {
            Game game = new Game();

            Assert.AreEqual(game.Play(0, 0), 0);
            Assert.AreEqual(game.Play(1, 0), 0);
            Assert.AreEqual(game.Play(0, 1), 0);
            Assert.AreEqual(game.Play(0, 2), 0);
            Assert.AreEqual(game.Play(2, 1), 0);
            Assert.AreEqual(game.Play(1, 1), 0);
            Assert.AreEqual(game.Play(2, 2), 0);
            Assert.AreEqual(game.Play(1, 2), 1);

            Assert.AreEqual(game.map[0, 0], 0);
            Assert.AreEqual(game.map[1, 0], 0);
            Assert.AreEqual(game.map[0, 1], 0);
            Assert.AreEqual(game.map[0, 2], 0);
            Assert.AreEqual(game.map[2, 1], 0);
            Assert.AreEqual(game.map[1, 1], 0);
            Assert.AreEqual(game.map[2, 2], 0);
            Assert.AreEqual(game.map[1, 2], 0);

            Assert.AreEqual(game.player, 1);

        }
    }
}
