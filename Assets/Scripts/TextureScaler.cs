using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScaler : MonoBehaviour
{
    void Start()
    {
        Vector3 scale = transform.localScale;
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(scale.x, scale.z);
    }
}

