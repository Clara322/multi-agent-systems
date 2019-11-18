using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        
        #region Public Fields

        public static GameManager Instance;
        
        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefab;
        #endregion
        
        #region Photon Callbacks
        
        void Start()
        {
            Instance = this;
            if (playerPrefab == null)
            {
                Debug.LogError("playerPrefab Reference missing",this);
            }
            else
            {
                PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(PhotonNetwork.LocalPlayer.ActorNumber % 10,0f,0f), Quaternion.identity, 0);
            }
        }
        public override void OnPlayerEnteredRoom(Player other)
        {
        }

        public override void OnPlayerLeftRoom(Player other)
        {
        }
        
        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        #endregion

        #region Private Methods


        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
                return;
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("Scene1");
        }


        #endregion
    }
}