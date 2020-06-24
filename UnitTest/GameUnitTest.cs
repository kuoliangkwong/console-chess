using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Numerics;

namespace console_chess_unit_test
{
    [TestClass]
    public class GameUnitTest
    {
        [TestMethod]
        public void TestCheckmateGame()
        {
            var moves = new string[]
            {
                "f2 f4",
                "e7 e6",
                "g2 g4",
                "d8 h4", // Checkmate
            };
            var game = new Game();
            Color? winner = null;
            string message = null;
            foreach(var move in moves)
            {
                var vecStr = move.Split(" ");
                var (player, msg) = game.Move(vecStr[0], vecStr[1]);
                winner = player;
                message = msg;
                game.NextTurn();
            }
            Assert.AreEqual(Color.Black, winner);
            Assert.AreEqual("Checkmate!!", message);
        }

        [TestMethod]
        public void TestCheckGame()
        {
            var moves = new string[]
            {
                "e2 e4",
                "e7 e6",
                "f2 f4",
                "d8 h4", // Check
            };
            var game = new Game();
            Color? winner = null;
            string message = null;
            foreach (var move in moves)
            {
                var vecStr = move.Split(" ");
                var (player, msg) = game.Move(vecStr[0], vecStr[1]);
                winner = player;
                message = msg;
                game.NextTurn();
            }
            Assert.AreEqual(null, winner);
            Assert.AreEqual("Check!!", message);
        }

        [TestMethod]
        public void TestWinGame()
        {
            var moves = new string[]
            {
                "e2 e4",
                "e7 e6",
                "d2 d4",
                "d8 h4",
                "f2 f4",
                "h4 e1",
            };
            var game = new Game();
            Color? winner = null;
            string message = null;
            foreach (var move in moves)
            {
                var vecStr = move.Split(" ");
                var (player, msg) = game.Move(vecStr[0], vecStr[1]);
                winner = player;
                message = msg;
                game.NextTurn();
            }
            Assert.AreEqual(Color.Black, winner);
            Assert.AreEqual(null, message);
        }

        [TestMethod]
        public void TestInvalidMoveGame()
        {
            var moves = new string[]
            {
                "e2 e4",
                "e7 e6",
                "g2 g4",
                "d8 h4",
                "d2 d4",
            };
            var game = new Game();
            foreach (var move in moves)
            {
                var vecStr = move.Split(" ");
                game.Move(vecStr[0], vecStr[1]);
                game.NextTurn();
            }
            try
            {
                game.Move("h4", "e1");
            } catch (Exception e)
            {
                Assert.AreEqual("Invalid Move", e.Message);
            }
            
        }

    }
}
