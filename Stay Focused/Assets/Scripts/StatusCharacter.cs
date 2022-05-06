using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCharacter : MonoBehaviour
{
    public bool hungry = true;
    private bool collect = false;
    public GameObject status;

    void FixedUpdate()
    {
        if (collect)
        {
            hungry = false;
            StartCoroutine(HungerState());
        }
    }

    IEnumerator HungerState()
    {
        yield return new WaitForSeconds(3f);
        collect = false;
        hungry = true;
        status.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            collect = true;
            status.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
