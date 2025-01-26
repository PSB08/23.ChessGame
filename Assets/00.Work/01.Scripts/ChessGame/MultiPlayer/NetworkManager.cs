using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private ChessUIManager uiManager;


    private void Update()
    {
        uiManager.SetConnectionStatus(PhotonNetwork.NetworkClientState.ToString());
    }

    public void Connet()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #region PhotonCallbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log($"Connected to server. Looking for random room");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"Joining random room failed Because of {message}, Creating a new One");
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"Player {PhotonNetwork.LocalPlayer.ActorNumber} joined the room");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Player {newPlayer.ActorNumber} entered the room");
    }

    #endregion

}
