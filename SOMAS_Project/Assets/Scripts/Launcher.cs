using UnityEngine;
using Photon.Pun;

using Photon.Realtime;
using UnityEngine.UI;

namespace Com.MyCompany.MyGame
{
    public class Launcher : MonoBehaviourPunCallbacks
    {

        #region Private Serializable Fields
        /// <summary>
/// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
/// </summary>
[Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
[SerializeField]
private byte maxPlayersPerRoom = 2;
        [Tooltip("Room name")]
        [SerializeField]
        public InputField roomNameField;
        [Tooltip("Join Room button")]
        [SerializeField]
        public GameObject joinButton;
        [Tooltip("Cancel Queue button")]
        [SerializeField]
        public GameObject cancelButton;

        #endregion


        #region Private Fields


        /// <summary>
        /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
        /// </summary>
        string gameVersion = "1";

        //private GameObject popup;


        #endregion


        #region MonoBehaviour CallBacks


        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {
            // #Critical
            // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }


        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
        {
            //Connect();
            cancelButton.SetActive(false);
        }


        #endregion


        #region Public Methods


        /// <summary>
        /// Start the connection process.
        /// - If already connected, we attempt joining a random room
        /// - if not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>
        public void Connect()
        {
            joinButton.SetActive(false);
            cancelButton.SetActive(true);
            Debug.Log("CODE START");
            Debug.Log(roomNameField.text);
            // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                //PhotonNetwork.JoinRandomRoom();
                PhotonNetwork.JoinOrCreateRoom(roomNameField.text, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom },new TypedLobby(roomNameField.text,LobbyType.Default));
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.GameVersion = gameVersion;
                PhotonNetwork.ConnectUsingSettings();

                Debug.Log("Need to start the conection");

            }
        }
        public void CancelQueue()
        {
            PhotonNetwork.Disconnect();
            cancelButton.SetActive(false);
            joinButton.SetActive(true);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log("ASJAJGSKSJK");
            //Doesn't get called on the local player, just remote players, so you would still need something to handle on the second player
            if (PhotonNetwork.PlayerList.Length == 2)
            {
                PhotonNetwork.LoadLevel("Scene1");
            }
            else if (PhotonNetwork.PlayerList.Length == 1)
            {
                Debug.Log("Not Enough PLayers");
            }
            Debug.Log("number of players");
            //Debug.Log(PhotonNetwork.PlayerList.Length);

        }



        #endregion

        #region MonoBehaviourPunCallbacks Callbacks


    private bool changeSceneFlag = false;
    
    public override void OnConnectedToMaster()
    {
            //Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            //PhotonNetwork.CreateRoom("Room");
            //PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom });
        Debug.Log("OnConnectedToMaster has been called");
            PhotonNetwork.JoinOrCreateRoom(roomNameField.text, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom }, new TypedLobby(roomNameField.text, LobbyType.Default));
            //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(" No room available so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
            Debug.Log("number of players");
            Debug.Log(PhotonNetwork.PlayerList.Length);
            if (PhotonNetwork.PlayerList.Length == 2) 
        {
                changeSceneFlag = true;
                Debug.Log("2 players yey");
            PhotonNetwork.LoadLevel ("Scene1");

        } 
        else if (PhotonNetwork.PlayerList.Length == this.maxPlayersPerRoom) 
        {
            Debug.Log ("Not Enough Players");

        }
    }
       

        #endregion
    }
}
