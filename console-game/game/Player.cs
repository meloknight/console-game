namespace console_game.game
{
    class Player
    {
        public int playerPositionX { get; set; }
        public int playerPositionY { get; set; }
        static int playerCount = 0;
        public int playerNumber { get; set; }
        public Player( int playerX, int playerY )
        {
            playerPositionX = playerX;
            playerPositionY = playerY;
            playerCount++;
            playerNumber = playerCount;
        }
    }
}
