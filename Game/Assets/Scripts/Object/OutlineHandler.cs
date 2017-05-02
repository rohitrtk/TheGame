using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineHandler : MonoBehaviour
{
    Renderer r;

    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        r.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

    private void OnMouseExit()
    {
        r.material.shader = Shader.Find("Diffuse");
    }

}
