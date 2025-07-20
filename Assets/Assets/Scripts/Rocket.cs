using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rocket : Obstacle
{
    private GameObject player;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    float playerPositionX;
    float playerPositionY;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.transform.position.x + 3)
        {
            Debug.Log(playerPositionX + ", " + playerPositionY);
            transform.position = Vector2.MoveTowards(transform.position,
                                        new Vector2(playerPositionX, playerPositionY),
                                        speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                       player.transform.position,
                                       speed * Time.deltaTime);

            playerPositionX = player.transform.position.x - 3f;
            playerPositionY = player.transform.position.y;
        }

        if (Vector2.Distance(transform.position, new Vector2(playerPositionX, playerPositionY)) < 0.1f)
        {
            Destroy(this.gameObject);
        }
    }


}

