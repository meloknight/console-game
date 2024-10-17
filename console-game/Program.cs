// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Player player1 = new Player(4, 0);
Player player2 = new Player(2, 2);
GameState gameStateObject = new GameState([player1, player2]);

static void GameLoop(GameState gameStateObject)
{
    while(!gameStateObject.isGameOver)
    {
        Console.WriteLine($"{gameStateObject.isGameOver}");
        Console.WriteLine("Would you like the game to be over? (yes / no): ");
        string end_game = Console.ReadLine();
        if (end_game == "yes")
        {
            gameStateObject.isGameOver = true;
            Console.WriteLine("The game is over!");
        }
        else
        {
            Console.WriteLine("The game continues!");
        }
    }
}
GameLoop(gameStateObject);

class Player
{
    public int playerPositionX { get; set; }
    public int playerPositionY { get; set; }
    static int playerCount = 0;
    public int playerNumber { get; set; }
    public Player (int playerX, int playerY)
    {
        playerPositionX = playerX;
        playerPositionY = playerY;
        playerCount++;
        playerNumber = playerCount;
    }
}

class GameState
{
    public bool isGameOver;
    public int playerTurn;
    public string[] gameBoard;
    private Player[] playerObjects;
    private int[] boardPositionMapX;
    private int[] boardPositionMapY;

    public GameState(Player[] playerObjects)
    {
        isGameOver = false;
        playerTurn = 1;
        int[] boardPositionMapX = new int[5] { 2, 6, 10, 14, 18 };
        int[] boardPositionMapY = new int[5] { 1, 3, 5, 7, 9 };
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
        UpdateGameBoard(gameBoard, playerObjects, boardPositionMapX, boardPositionMapY);
        DrawBoard(gameBoard);

    }

    public void UpdateGameBoard(string[] gameBoard, Player[] players, int[] boardMapX, int[] boardMapY)
    {

        if (players != null)
        {
            for (int i = 0; i < players.Length; i++)
            {
                var player = players[i];
                var playerPositionX = player.playerPositionX;
                var playerPositionY = player.playerPositionY;
                int playerPositionMappedX = boardMapX[playerPositionX];
                int playerPositionMappedY = boardMapY[playerPositionY];
                Console.WriteLine($"player number: {player.playerNumber}, X position: {playerPositionMappedX}, Y position: {playerPositionMappedY}");
                string gameBoardY = gameBoard[playerPositionMappedY];
                char[] tempCharArray = gameBoardY.ToCharArray();
                tempCharArray[playerPositionMappedX] = 'A';
                string resultString = new string(tempCharArray);
                gameBoard[playerPositionMappedY] = resultString;
            }
            DrawBoard(gameBoard);
        }
        else
        {
            Console.WriteLine("null friendo!");
        }
        
    }

    public void DrawBoard(string[] currentBoard)
    {
        for (int i = 0; i < currentBoard.Length; i++)
        {
            Console.WriteLine(currentBoard[i]);
        }
        Console.WriteLine("---------------------");
    }

}
