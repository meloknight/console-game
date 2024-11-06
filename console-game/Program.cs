// See https://aka.ms/new-console-template for more information
using console_game.game;


// object creation
Player player1 = new Player( 0, 0 );
Player player2 = new Player( 4, 4 );
Player[] players = { player1, player2 };
Screen screen = new Screen();
GameState gameStateObject = new GameState( players, screen );
PlayerInput playerInputObject = new PlayerInput();


// Game Loop for the entire game. Goes through player input, logic, and updating screen.
static void GameLoop( GameState gameStateObject, Screen screen, Player[] players, PlayerInput playerInputObject )
{
    // initialize!!
    Console.WriteLine( "-----SQUARE GAME-----\n" );
    Player currentPlayer = players[0];
    screen.DrawBoard( gameStateObject.gameBoard );

    while ( !gameStateObject.isGameOver )
    {
        // PLAYER INPUT!!!


        //foreach ( Player player in players )
        //{
        //    if ( player.playerNumber == gameStateObject.playerTurn )
        //    {
        //        currentPlayer = player;
        //    }
        //}
        currentPlayer = playerInputObject.determineCurrentPlayer( players, gameStateObject );

        Console.WriteLine( "End the game at any time by typing 'end'." );
        Console.WriteLine( $"Player {currentPlayer.playerNumber}, which direction would you like to move?: " );
        string player_action = Console.ReadLine().ToLower();

        // GAME LOGIC!!!

        switch ( player_action )
        {
            case "end":
                gameStateObject.isGameOver = true;
                Console.WriteLine( "The game is over! Have a Nice Day!" );
                break;
            case "up":
                if ( currentPlayer.playerPositionY > 0 )
                {
                    currentPlayer.playerPositionY--;
                }
                else
                {
                    currentPlayer.playerPositionY = 4;
                }
                break;
            case "down":
                if ( currentPlayer.playerPositionY < 4 )
                {
                    currentPlayer.playerPositionY++;
                }
                else
                {
                    currentPlayer.playerPositionY = 0;
                }
                break;
            case "left":
                if ( currentPlayer.playerPositionX > 0 )
                {
                    currentPlayer.playerPositionX--;
                }
                else
                {
                    currentPlayer.playerPositionX = 4;
                }
                break;
            case "right":
                if ( currentPlayer.playerPositionX < 4 )
                {
                    currentPlayer.playerPositionX++;
                }
                else
                {
                    currentPlayer.playerPositionX = 0;
                }
                break;
            default:
                Console.WriteLine( $"Player {currentPlayer.playerNumber} stands and stares into space. Eyes unfocused, hands sweaty..." );
                break;
        }

        gameStateObject.UpdateGameBoard( players );
        Console.WriteLine( "\n---------------------" );
        Console.WriteLine( $"\nPlayer {currentPlayer.playerNumber} is at X: {currentPlayer.playerPositionX} and Y: {currentPlayer.playerPositionY}\n" );

        // UPDATE SCREEN!!!
        screen.DrawBoard( gameStateObject.gameBoard );

        // NEXT PLAYER!!!
        if ( gameStateObject.playerTurn == 1 ) { gameStateObject.playerTurn = 2; }
        else { gameStateObject.playerTurn = 1; }
    }
}
GameLoop( gameStateObject, screen, players, playerInputObject );
