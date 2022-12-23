using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float health = 5f;
    void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag != "Player")
            health--;
        if(health==0)Destroy(gameObject);
    }
}
