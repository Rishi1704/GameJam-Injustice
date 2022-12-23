using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag != "Player")
            //Play animation and destroy game object
            Destroy(gameObject);
    }
}
