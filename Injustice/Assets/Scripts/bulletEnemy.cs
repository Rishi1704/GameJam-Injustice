using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    bool change = true;
    private Vector2 starting;
    private Vector2 end;
    public Vector2 distance;
    public float speed = 1f;
    public Rigidbody2D rigidBody;
    private Vector2 dir2;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        starting = transform.position;
        end = starting + distance;
        dir2 = distance;
        dir2.Normalize();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir1 = starting - (Vector2)player.position;
        dir1.Normalize();
        if ((dir1 == dir2 && !change) || (dir1 == (-dir2) && change))
        {
            //enemy sees player
            Shoot();

        }
        else
        {
            //Back and forth movement
            if (change)
            {
                movestarttoend();
            }
            else
            {
                moveendtostart();
            }

            if (change && ((Vector2)transform.position == end))
            {
                change = false;
                rigidBody.rotation = 180;

            }
            else if (!change && ((Vector2)transform.position == starting))
            {
                change = true;
                rigidBody.rotation = 0;
            }
        }
        //Back and forth movement





    }
    void movestarttoend()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, end, speed * Time.deltaTime);
    }
    void moveendtostart()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, starting, speed * Time.deltaTime);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidBodyBullet = bullet.GetComponent<Rigidbody2D>();
        rigidBodyBullet.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
