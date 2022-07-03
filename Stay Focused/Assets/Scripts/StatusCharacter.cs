using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCharacter : MonoBehaviour
{
    public bool hungry = true;
    private bool collect = false;
    public GameObject status;

    public static StatusCharacter instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (collect)
        {
            HungryBar.instance.AddStamina(2);
            collect = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable") && hungry)
        {
            collect = true;
            Destroy(collision.gameObject);
        }
    }
}
