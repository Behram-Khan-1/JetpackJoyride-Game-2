using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScroller : MonoBehaviour
{
    public Material floorMaterial;
    public float scrollSpeed = 0.5f;

    
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        floorMaterial.mainTextureOffset = new Vector2(offset, 0);
    }
}
