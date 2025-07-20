using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public List<GameObject> backgrounds;
    public float speed = 2f;
    GameObject lastBG, middleBG;

    public event Action<GameObject> OnBackgroundMoved;

    void Start()
    {
        lastBG = backgrounds.Last();
        middleBG = backgrounds[backgrounds.Count - 2];
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].transform.Translate(new Vector3(-speed, 0, 0));
        }
    }

    public void MoveToBack(GameObject collidedBG)
    {
        collidedBG.transform.position = lastBG.transform.position + new Vector3(
                   15, 0, 0
       );
        middleBG = lastBG;
        lastBG = collidedBG;
      
      OnBackgroundMoved.Invoke(collidedBG);
    }

    public GameObject GetMiddleBackground()
    {
        return middleBG;
    }


}

