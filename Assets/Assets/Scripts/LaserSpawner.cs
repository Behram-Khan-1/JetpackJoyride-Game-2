using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laserObstacle;
    private Vector2 centerPoint;
    private float minX = -5;
    private float maxX = 5;
    private float minY = -2f;
    private float maxY = 2f;

    private float angle = 30f;
    private float maxHeight = 4f;
    private float minHeight = 3f;

    GameObject spawnedLaser;


    public void LaserSpawn(GameObject middleBG)
    {
        centerPoint = middleBG.transform.position;

        var randomX = Random.Range(minX, maxX);
        var randomY = Random.Range(minY, maxY);
        var randomAngle = Random.Range(angle, -angle);

        spawnedLaser = Instantiate(laserObstacle,
        new Vector2(centerPoint.x + randomX, centerPoint.y + randomY),
                    Quaternion.Euler(0, 0, randomAngle),
                     middleBG.transform);

        var randomHeight = Random.Range(minHeight, maxHeight);
        spawnedLaser.GetComponent<SpriteRenderer>().size = new Vector2(0.39f, randomHeight);
    }


    public void DestroyLaser(GameObject Bg)
    {
        if(Bg.transform.childCount > 0)
        {
            // Destroy the laser child object
            Destroy(Bg.transform.GetChild(0).gameObject);
        }
        else
        {
            Debug.Log("No laser to destroy in this background.");
        }
    }
}
