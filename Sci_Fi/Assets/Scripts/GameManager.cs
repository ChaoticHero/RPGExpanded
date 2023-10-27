using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class GameManager : MonoBehaviourPun
{
    [Header("Players")]
    public string playerPrefabPath;
    public PlayerController[] players;
    public Transform[] spawnPoints;
    public float respawnTime;
    private int playersInGame;

    // instance
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    [PunRPC]
    void ImInGame()
    {
        playersInGame++;

        if (playersInGame == PhotonNetwork.PlayerList.Length)
            SpawnPlayer();
    }
    void Start()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }

  
    void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabPath, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        // initialize player
        playerObj.GetComponent<PhotonView>().RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
    public PlayerController GetPlayer(int playerId)
    {
        //return players.First(x => x.id == playerId);

        // handle disconnected player possibility
        foreach (PlayerController player in players)
        {
            if (player != null && player.id == playerId)
                return player;
        }
        return null;
    }
    public PlayerController GetPlayer(GameObject playerObj)
    {
        //return players.First(x => x.gameObject == playerObj);

        // handle disconnected player possibility
        foreach (PlayerController player in players)
        {
            if (player != null && player.gameObject == playerObj)
                return player;
        }
        return null;
    }
}