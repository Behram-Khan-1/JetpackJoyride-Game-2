using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleCoordinator : MonoBehaviour
{
    public BackgroundScroller backgroundScroller;
    // Start is called before the first frame update
    public LaserSpawner laserSpawner;
    public RocketSpawner rocketSpawner;

    void Awake()
    {
        backgroundScroller.OnBackgroundMoved += InstantiateObstacle;
    }

    void Start()
    {
        InvokeRepeating("SpawnRocket", 5f, 13);
    }

    void InstantiateObstacle(GameObject collidedBG)
    {
        laserSpawner.DestroyLaser(collidedBG);
        laserSpawner.LaserSpawn(backgroundScroller.GetMiddleBackground());
    }
    void SpawnRocket()
    {
        rocketSpawner.StartRocketSpawn();
    }
    

}