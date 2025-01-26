using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [Header("Game mode dependent objects")]
    [SerializeField] private SinglePlayerChessGameController singlePlayerChessGameController;
    [SerializeField] private MultiPlayerChessGameController multiPlayerChessGameController;
    [SerializeField] private SinglePlayerBoard singlePlayerBoard;
    [SerializeField] private MultiPlayerBoard multiPlayerBoard;

    [Header("Scene references")]
    [SerializeField] private NetworkManager networkManager;
    [SerializeField] private ChessUIManager chessUIManager;
    [SerializeField] private Transform boardAnchor;

    public void CreateMultiPlayerBoard()
    {
        if (!networkManager.IsRoomFull())
        {
            PhotonNetwork.Instantiate(multiPlayerBoard.name, boardAnchor.position, boardAnchor.rotation);
        }
    }

    public void CreateSinglePlayerBoard()
    {
        Instantiate(singlePlayerBoard, boardAnchor);
    }

    public void InitializeMultiplayerController()
    {
        MultiPlayerBoard board = FindObjectOfType<MultiPlayerBoard>();
        if (board)
        {
            MultiPlayerChessGameController controller = Instantiate(multiPlayerChessGameController);
            controller.SetDependencies(chessUIManager, board);
            controller.CreatePlayers();
            controller.SetMultiplayerDependencies(networkManager);
            networkManager.SetDependencies(controller);
            board.SetDependencies(controller);
        }
    }


}
