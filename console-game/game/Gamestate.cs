namespace console_game.game
{
    class GameState
    {
        public bool isGameOver;
        public int playerTurn;
        public string[] gameBoard = new string[11]
            {
            // 0   1   2   3   4
            "+ - + - + - + - + - +",
            "|   |   |   |   |   |", // 0
            "+ - + - + - + - + - +",
            "|   |   |   |   |   |", // 1
            "+ - + - + - + - + - +",
            "|   |   |   |   |   |", // 2
            "+ - + - + - + - + - +",
            "|   |   |   |   |   |", // 3
            "+ - + - + - + - + - +",
            "|   |   |   |   |   |", // 4
            "+ - + - + - + - + - +",
            };
        private Player[] playerObjects;
        private int[] boardPositionMapX { get; set; } = new int[5] { 2, 6, 10, 14, 18 };
        private int[] boardPositionMapY { get; set; } = new int[5] { 1, 3, 5, 7, 9 };
        private Screen screen;

        public GameState( Player[] playerObjects, Screen screen )
        {
            isGameOver = false;
            playerTurn = 1;
            UpdateGameBoard( playerObjects );
        }

        public void UpdateGameBoard( Player[] players )
        {
            if ( players != null )
            {
                gameBoard = new string[11]
                {
                    "+ - + - + - + - + - +",
                    "|   |   |   |   |   |",
                    "+ - + - + - + - + - +",
                    "|   |   |   |   |   |",
                    "+ - + - + - + - + - +",
                    "|   |   |   |   |   |",
                    "+ - + - + - + - + - +",
                    "|   |   |   |   |   |",
                    "+ - + - + - + - + - +",
                    "|   |   |   |   |   |",
                    "+ - + - + - + - + - +",
                };
                for ( int i = 0; i < players.Length; i++ )
                {
                    var player = players[i];
                    int playerPositionMappedX = boardPositionMapX[player.playerPositionX];
                    int playerPositionMappedY = boardPositionMapY[player.playerPositionY];

                    string gameBoardY = gameBoard[playerPositionMappedY];
                    char[] tempCharArray = gameBoardY.ToCharArray();

                    if ( player.playerNumber == 1 )
                    {
                        tempCharArray[playerPositionMappedX] = '1';
                    }
                    else if ( player.playerNumber == 2 )
                    {
                        tempCharArray[playerPositionMappedX] = '2';
                    }
                    else
                    {
                        tempCharArray[playerPositionMappedX] = '?';
                    }

                    string resultString = new string( tempCharArray );
                    gameBoard[playerPositionMappedY] = resultString;
                }
            }
            else
            {
                Console.WriteLine( "null friendo!" );
            }

        }
    }
}
