// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, Console Gamer!");


Player player1 = new Player(4, 0);
Player player2 = new Player(2, 2);
Console.WriteLine($"{player1.playerPositionX}, {player1.playerPositionY}, {player1.playerNumber}");
Console.WriteLine($"{player2.playerPositionX}, {player2.playerPositionY}, {player2.playerNumber}");
//int[] boardPositionMapX = new int[5] { 2, 6, 10, 14, 18};
//int[] boardPositionMapY = new int[5] { 1, 3, 5, 7, 9 };
GameState gameStateObject = new GameState([player1, player2]);
Console.WriteLine($"{gameStateObject.isGameOver}, {gameStateObject.playerTurn}");

//gameStateObject.UpdateGameBoard();
DrawBoard(gameStateObject.gameBoard);

static void DrawBoard(string[] currentBoard) 
{
    for (int i = 0; i < currentBoard.Length; i++)
    {
    Console.WriteLine(currentBoard[i]);
    }
}

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
        Console.WriteLine(playerObjects);
        for (int i = 0; i < playerObjects.Length; i++)
        {
            Console.WriteLine(playerObjects[i].playerNumber);
        }
        //Player[] playerObjects = playerObjects;
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
        //int playerObjectsLength = playerObjects.Length;
        //for (var i = 0; i < playerObjectsLength; i++)
        //{
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
                
            }
        }
        else
        {
            Console.WriteLine("null friendo!");
        }
        //}
    }

    public void DrawBoard(string[] currentBoard)
    {
        for (int i = 0; i < currentBoard.Length; i++)
        {
            Console.WriteLine(currentBoard[i]);
        }
    }

}