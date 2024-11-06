namespace console_game.game
{
    internal class PlayerInput
    {

        public Player determineCurrentPlayer( Player[] players, GameState gameStateObject )
        {
            foreach ( Player player in players )
            {
                if ( player.playerNumber == gameStateObject.playerTurn )
                {
                    return player;
                }
            }
            return players[0];
        }


    }
}
