using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    public float scrollSpeed = 1;
    private Vector2 scroll = new Vector2();

    public bool useCustomShader = true;
    public string shaderVariableName = "_TextureOffset";

    public int horScrollValue = 0, verScrollValue = 0;

    void Update()
    {
        if (useCustomShader)
        {
            scroll += new Vector2(0f, Time.deltaTime * scrollSpeed);
            GetComponent<Renderer>().material.SetVector(shaderVariableName, scroll);
            //GetComponent<Renderer>().material.SetVector("_TextureScale", scale);
        }
        else
        {
            scroll += new Vector2(Time.deltaTime * horScrollValue * scrollSpeed, Time.deltaTime * verScrollValue * scrollSpeed);
            GetComponent<Renderer>().material.mainTextureOffset = scroll;
            //GetComponent<Renderer>().material.SetVector("_TextureScale", scale);
        }
    }
}
