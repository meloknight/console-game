namespace console_game.game
{
    internal class Screen
    {
        public void DrawBoard( string[] currentBoard )
        {
            for ( int i = 0; i < currentBoard.Length; i++ )
            {
                Console.WriteLine( currentBoard[i] );
            }
            Console.WriteLine( "\n---------------------\n" );
        }
    }
}