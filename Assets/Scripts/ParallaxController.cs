//Jade Lee
//This code manages the moving background animation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxController : MonoBehaviour
{
    public float speed;         //speed of the background movement
    public Renderer rend;       //background renderer

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
}//ParallaxController