using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public GameObject goScorer;

    private void Start()
    {
        goScorer = GameObject.Find("Keeper");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Start");
            scoreKeeper script = goScorer.GetComponent<scoreKeeper>();

            GameObject parent = transform.parent.gameObject;

            script.Score(parent);

            Debug.Log("End");

        }
    }
}
