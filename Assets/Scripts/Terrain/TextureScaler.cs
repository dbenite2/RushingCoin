using UnityEngine;

// It will scalate the given texture of the object to it, giving a better look
// works better when the object is scaled in big proportions

public class TextureScaler : MonoBehaviour {
    void Start() {
        Vector3 scale = transform.localScale;
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(scale.x, scale.z);
    }
}

