using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour {

    //public List<GameObject> players = new List<GameObject>();
    public List<int> playerScore = new List<int>();

    public Spawner spawnerObj;

    //private void Start()
    //{
    //    players.Add(GameObject.Find("player"));
    //}

    public void AddPlayer(GameObject player)
    {
        //spawnerObj.players.Add(player);
        playerScore.Add(0);
    }

    public void Score(GameObject scoringPlayer)
    {
        int x = 0;
        foreach (KeyValuePair<string, GameObject> player in spawnerObj.players)
        {
            if (player.Value == scoringPlayer)
            {
                playerScore[x]++;
                break;
            }
            x++;
        }

        ResetPlayers();
    }

    void ResetPlayers()
    {
        //int x = -5;
        foreach(KeyValuePair<string, GameObject> player in spawnerObj.players)
        {
            spawnerObj.ReSpawnPlayer(player.Value);

            //    player.GetComponent<Rigidbody2D>().position = new Vector2(0+x, -5);
            //    player.GetComponent<Rigidbody2D>().rotation = 0f;
            //    x += 7;
        }

    }
}
