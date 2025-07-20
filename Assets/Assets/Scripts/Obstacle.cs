using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle player collision with the obstacle
            Debug.Log("Player collided with obstacle!");
            Debug.Log(this);
            Destroy(this.gameObject);

            GameManager.Instance.DecreaseHealth();

        }
    }
}
