using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

public class MultiPlayerChessGameController : ChessGameController, IOnEventCallback
{
    protected const byte SET_GAME_STATE_EVENT_CODE = 1;

    private ChessPlayer localPlayer;
    private NetworkManager networkManger;

    public void SetMultiplayerDependencies(NetworkManager networkManager)
    {
        this.networkManger = networkManager;
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override bool CanPerformMove()
    {
        if (!IsGameInProgress() || !ILocalPlayersTurn())
            return false;
        return true;
    }

    private bool ILocalPlayersTurn()
    {
        return localPlayer == activePlayer;
    }

    public void SetLocalPlayer(TeamColor team)
    {
        localPlayer = team == TeamColor.White ? whitePlayer : blackPlayer;
    }

    public override void TryToStartCurrentGame()
    {
        if (networkManger.IsRoomFull())
        {
            SetGameState(GameState.Play);
        }
    }

    protected override void SetGameState(GameState state)
    {
        object[] content = new object[] { (int)state };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        PhotonNetwork.RaiseEvent(SET_GAME_STATE_EVENT_CODE, content, raiseEventOptions, SendOptions.SendReliable);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if (eventCode == SET_GAME_STATE_EVENT_CODE)
        {
            object[] data = (object[])photonEvent.CustomData;
            GameState state = (GameState)data[0];
            this.state = state;
        }
    }


}
