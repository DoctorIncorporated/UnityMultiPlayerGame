using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Spawner : MonoBehaviour {

    public GameObject localPlayer;
    public GameObject playerPrefab;
    public GameObject scoreKeeper;
    public SocketIOComponent socket;

    public Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    Vector3[] spawns = { new Vector3(-15,7,0), new Vector3(-15,-7,0), new Vector3(15,-7,0), new Vector3(15,7,0) };

    public GameObject SpawnPlayer(string id)
    {
        int x = Random.Range(0, 4);

        var player = Instantiate(playerPrefab, spawns[x], Quaternion.identity) as GameObject;

        id = id.Replace("\"", "");
        player.GetComponent<NetworkEntity>().id = id;
        AddPlayer(id, player);

        scoreKeeper.GetComponent<scoreKeeper>().AddPlayer(player);

        return player;
    }
    public GameObject ReSpawnPlayer(GameObject player)
    {
        int x = Random.Range(0,4);

        player.GetComponent<Rigidbody2D>().position = spawns[x];
        player.GetComponent<Rigidbody2D>().rotation = 0f;//(x > 1) ? 90f :-90f;

        return player;
    }

    public void AddPlayer(string id, GameObject player)
    {
        id = id.Replace("\"", "");
        players.Add(id, player);        
    }

    public GameObject FindPlayer(string id)
    {
        id = id.Replace("\"", "");
        return players[id];
    }

    public void RemovePlayer(string id)
    {
        id = id.Replace("\"", "");
        var player = players[id];

        Destroy(player);
        players.Remove(id);
    }
}
