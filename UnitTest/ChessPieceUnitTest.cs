using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace console_chess_unit_test
{
    [TestClass]
    public class ChessPieceUnitTest
    {
        [TestMethod]
        public void TestKing()
        {
            var king = new King(Color.White);
            var board = new Board();
            board.Occupants[3, 0] = king;

            Assert.IsTrue(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(4, 0),
                board
            ));

            Assert.IsTrue(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(3, 1),
                board
            ));

            Assert.IsTrue(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(2, 0),
                board
            ));

            Assert.IsTrue(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(4, 1),
                board
            ));

            Assert.IsTrue(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(2, 1),
                board
            ));

            Assert.IsFalse(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(1, 1),
                board
            ));

            Assert.IsFalse(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(5, 2),
                board
            ));

            board.Occupants[2, 1] = new Pawn(Color.Black);
            board.Occupants[4, 1] = new Pawn(Color.White);

            Assert.IsTrue(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(2, 1),
                board
            ));

            Assert.IsFalse(king.CheckValidMove(
                new Vector2Int(3, 0),
                new Vector2Int(4, 1),
                board
            ));
        }

        [TestMethod]
        public void TestQueen()
        {
            var queen = new Queen(Color.White);
            var board = new Board();
            board.Occupants[0, 4] = queen;

            Assert.IsTrue(queen.CheckValidMove(
                new Vector2Int(0, 4),
                new Vector2Int(2, 6),
                board
            ));

            Assert.IsTrue(queen.CheckValidMove(
                new Vector2Int(0, 4),
                new Vector2Int(0, 6),
                board
            ));

            Assert.IsFalse(queen.CheckValidMove(
                new Vector2Int(0, 4),
                new Vector2Int(1, 6),
                board
            ));

            board.Occupants[1, 5] = new Pawn(Color.White);

            Assert.IsFalse(queen.CheckValidMove(
                new Vector2Int(0, 4),
                new Vector2Int(2, 6),
                board
            ));
        }

        [TestMethod]
        public void TestRook()
        {
            var rook = new Rook(Color.White);
            var board = new Board();
            board.Occupants[0, 0] = rook;

            // Test nature
            // - If can move diagonal
            // - If can move straight
            // - If can move 1 step
            // - If can move multiple steps
            Assert.IsTrue(rook.CheckValidMove(
                new Vector2Int(0, 0),
                new Vector2Int(0, 4),
                board
            ));

            Assert.IsTrue(rook.CheckValidMove(
                new Vector2Int(0, 0),
                new Vector2Int(4, 0),
                board
            ));

            Assert.IsFalse(rook.CheckValidMove(
                new Vector2Int(0, 0),
                new Vector2Int(4, 4),
                board
            ));

            board.Occupants[0, 2] = new Pawn(Color.Black);

            // Test blocking
            Assert.IsFalse(rook.CheckValidMove(
                new Vector2Int(0, 0),
                new Vector2Int(0, 4),
                board
            ));

            // Test attack
            Assert.IsTrue(rook.CheckValidMove(
                new Vector2Int(0, 0),
                new Vector2Int(0, 2),
                board
            ));

            board.Occupants[0, 1] = new Pawn(Color.White);
            Assert.IsFalse(rook.CheckValidMove(
                new Vector2Int(0, 0),
                new Vector2Int(0, 2),
                board
            ));
        }

        [TestMethod]
        public void TestBishop()
        {
            var bishop = new Bishop(Color.White);
            var board = new Board();
            board.Occupants[2, 0] = bishop;

            // Test nature
            // - If can move diagonal
            // - If can move straight
            // - If can move 1 step
            // - If can move multiple steps
            Assert.IsFalse(bishop.CheckValidMove(
                new Vector2Int(2, 0),
                new Vector2Int(2, 2),
                board
            ));

            Assert.IsFalse(bishop.CheckValidMove(
                new Vector2Int(2, 0),
                new Vector2Int(4, 0),
                board
            ));

            Assert.IsTrue(bishop.CheckValidMove(
                new Vector2Int(2, 0),
                new Vector2Int(4, 2),
                board
            ));

            Assert.IsFalse(bishop.CheckValidMove(
                new Vector2Int(2, 0),
                new Vector2Int(4, 1),
                board
            ));

            board.Occupants[3, 1] = new Pawn(Color.Black);

            // Test blocking
            Assert.IsFalse(bishop.CheckValidMove(
                new Vector2Int(2, 0),
                new Vector2Int(5, 3),
                board
            ));

            // Test attack
            Assert.IsTrue(bishop.CheckValidMove(
                new Vector2Int(2, 0),
                new Vector2Int(3, 1),
                board
            ));

            board.Occupants[5, 3] = new Pawn(Color.Black);
            board.Occupants[3, 1] = new Pawn(Color.White);
            Assert.IsFalse(bishop.CheckValidMove(
                new Vector2Int(2, 0),
                new Vector2Int(5, 3),
                board
            ));
        }

        [TestMethod]
        public void TestKnight()
        {
            var knight = new Knight(Color.White);
            var board = new Board();
            board.Occupants[1, 0] = knight;

            // Test nature
            // - If can move diagonal
            // - If can move straight
            // - If can move 1 step
            // - If can move multiple steps
            Assert.IsTrue(knight.CheckValidMove(
                new Vector2Int(1, 0),
                new Vector2Int(0, 2),
                board
            ));

            Assert.IsTrue(knight.CheckValidMove(
                new Vector2Int(1, 0),
                new Vector2Int(2, 2),
                board
            ));

            Assert.IsTrue(knight.CheckValidMove(
                new Vector2Int(1, 0),
                new Vector2Int(3, 1),
                board
            ));


            // Test blocking
            board.Occupants[2, 1] = new Pawn(Color.Black);
            Assert.IsTrue(knight.CheckValidMove(
                new Vector2Int(1, 0),
                new Vector2Int(2, 2),
                board
            ));


            // Test attack
            board.Occupants[2, 2] = new Pawn(Color.Black);
            
            Assert.IsTrue(knight.CheckValidMove(
                new Vector2Int(1, 0),
                new Vector2Int(2, 2),
                board
            ));

            board.Occupants[2, 2] = new Pawn(Color.White);
            Assert.IsFalse(knight.CheckValidMove(
                new Vector2Int(1, 0),
                new Vector2Int(2, 2),
                board
            ));
        }

        [TestMethod]
        public void TestPawn()
        {
            var pawn = new Pawn(Color.White);
            var board = new Board();
            board.Occupants[0, 1] = pawn;

            Assert.IsTrue(pawn.CheckValidMove(
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                board
            ));

            Assert.IsTrue(pawn.CheckValidMove(
                new Vector2Int(0, 1),
                new Vector2Int(0, 3),
                board
            ));

            Assert.IsFalse(pawn.CheckValidMove(
                new Vector2Int(0, 1),
                new Vector2Int(0, 0),
                board
            ));

            Assert.IsFalse(pawn.CheckValidMove(
                new Vector2Int(0, 1),
                new Vector2Int(1, 2),
                board
            ));

            pawn.hasMoved = true;

            Assert.IsFalse(pawn.CheckValidMove(
                new Vector2Int(0, 1),
                new Vector2Int(0, 3),
                board
            ));

            board.Occupants[0, 2] = new Pawn(Color.Black);
            board.Occupants[1, 2] = new Pawn(Color.Black);

            Assert.IsFalse(pawn.CheckValidMove(
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                board
            ));

            Assert.IsTrue(pawn.CheckValidMove(
                new Vector2Int(0, 1),
                new Vector2Int(1, 2),
                board
            ));
        }
    }
}
