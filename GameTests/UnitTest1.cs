using WpfApp1_etap0_;
using WpfApp1_etap0_.ViewModels;

namespace GameTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestTest()
        {
            Assert.Equal(5, 5);
        }

        [Fact]
        public void BoardTest()
        {
            Board board = new Board();
            Assert.False(board.isBoardFullFilled());
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board.GameBoard[i, j] = "1";
                }
            }
            Assert.True(board.isBoardFullFilled());
        }
    }
}