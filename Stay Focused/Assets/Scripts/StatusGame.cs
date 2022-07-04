using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("character") && gameObject.tag == "restart")
        {
            GameManager.instance.Restart();
        }

        if (collision.gameObject.CompareTag("character") && gameObject.tag == "next")
        {
            GameManager.instance.NextScene();
        }
    }
}
