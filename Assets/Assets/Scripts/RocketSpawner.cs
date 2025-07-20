using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketObstacle;
    public GameObject rocketUI;
    GameObject player;
    private bool isRocketSpawned = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartRocketSpawn()
    {
        isRocketSpawned = false;
        rocketUI.SetActive(true);
    }

    void Update()
    {
        if (!isRocketSpawned)
            RocketUIMovement();
    }

    float time;
    public void RocketUIMovement()
    {
        rocketUI.transform.position = new Vector2(  rocketUI.transform.position.x,
                                                    player.transform.position.y);

        time += Time.deltaTime;
        if (time > 3f)
        {
            isRocketSpawned = true;
            rocketUI.SetActive(false);
            time = 0f;
            SpawnRocket();
        }
    }

    private void SpawnRocket()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 138);
        var rocketPosition = new Vector2(rocketUI.transform.position.x + 2, rocketUI.transform.position.y);
        Instantiate(rocketObstacle, rocketPosition, rotation);
    }

}
