using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        var gameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManagerObj == null)
            Debug.LogError("Coin could not find GameManager");
        else
            gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameManager.IncresePoints(1);
            Destroy(this.gameObject);
    }
}
