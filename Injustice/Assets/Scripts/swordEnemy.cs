using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordEnemy : MonoBehaviour
{
    public Transform player;
    bool change=true;
    private Vector2 starting;
    private Vector2 end;
    public Vector2 distance;
    public float speed = 1f;
    public float newspeed = 2f;
    public Rigidbody2D rigidBody;
    private Vector2 dir2;

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
            movetowardsplayer();
            if (!change)
            {
                starting = transform.position;
                end = starting + distance;
            }
            else
            {
                end = transform.position;
                starting = end - distance;
            }
        }
        else
        {
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
        
        

        //enemy sees player

        
    }
    void movestarttoend()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, end, speed * Time.deltaTime);
    }
    void moveendtostart()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, starting, speed * Time.deltaTime);
    }
    void movetowardsplayer()
    {
        transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)player.position, newspeed * Time.deltaTime);
    }
}
