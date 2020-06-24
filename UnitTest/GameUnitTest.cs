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

        [TestMethod]
        public void TestNormalGame()
        {
            var moves = new string[]
            {
                "g2 g4", "g7 g6", "f1 g2", "b7 b5",
                "b1 c3", "c7 c6", "b2 b3", "g8 f6", 
                "f2 f3", "f8 h6", "g1 h3", "b8 a6",
                "g4 g5", "h6 g5", "h3 g5", "b5 b4", 
                "c3 a4", "a8 b8", "c1 b2", "d7 d5",
                "b2 f6", "e7 f6", "c2 c4", "d5 c4",
                "b3 c4", "f6 g5", "a1 b1", "d8 a5",
                "a4 b2", "a5 a2", "d1 c2", "b4 b3",
                "c2 c1", "a2 a4", "d2 d3", "e8 e7",
                "c1 g5", "e7 e8", "g5 e5", "e8 f8",
                "e5 b8"
            };
            var game = new Game();
            foreach (var move in moves)
            {
                var vecStr = move.Split(" ");
                game.Move(vecStr[0], vecStr[1]);
                game.NextTurn();
            }

            Assert.AreEqual(Color.Black, game.CurrentTurn);

            var numOfPieces = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var piece = game.Board.Occupants.SafeGetValue(i, j);
                    if (piece != null)
                    {
                        numOfPieces++;
                    }
                }
            }
            Assert.AreEqual(22, numOfPieces);
        }
    }
}
