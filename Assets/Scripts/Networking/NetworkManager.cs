using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.UtilityScripts;

public class NetworkManager : SingletonPUN<NetworkManager>
{
    private const string PLAYER_PREFAB_NAME = "Player";
    [SerializeField]
    private Sprite[] playerIcons;

    private void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            return;
        }

        // Spawn the player
        PhotonNetwork.Instantiate(PLAYER_PREFAB_NAME, Vector3.zero, Quaternion.identity);
    }

    public Sprite GetPlayerIcon(int id)
    {
        if (id < playerIcons.Length)
        {
            return playerIcons[id];
        }
        else
        {
            Debug.LogError($"Cannot access sprite with id {id}");
        }
        return null;
    }
}
