using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float Playerhealth = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet1")
            Playerhealth--;
    }

    void Update()
    {
        if(Playerhealth <= 0f)
            Destroy(gameObject);
    }
}
