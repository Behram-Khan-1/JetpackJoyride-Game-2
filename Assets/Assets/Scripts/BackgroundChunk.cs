using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundChunk : MonoBehaviour
{
    public BackgroundScroller backgroundScroller;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
        backgroundScroller.MoveToBack(other.gameObject);
    }
}
 