using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.3f;
    private MeshRenderer meshRenderer;
    private string MAIN_TEX = "_MainTex";

    public void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        Scroll();
    }

    public void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(MAIN_TEX);
        offset.y += Time.deltaTime * scrollSpeed;

        meshRenderer.sharedMaterial.SetTextureOffset(MAIN_TEX, offset);
    }
}
