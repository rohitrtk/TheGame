using UnityEngine;

/// <summary>
/// Handles setting the shader for this object
/// </summary>
public class OutlineHandler : MonoBehaviour
{
    /// <summary>
    /// Renderer object
    /// </summary>
    Renderer r; 

    /// <summary>
    /// This method is called upon object init
    /// </summary>
    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    /// <summary>
    /// Called when players hover mouse over this object
    /// </summary>
    private void OnMouseEnter()
    {
        r.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

    /// <summary>
    /// Called when players mouse leaves this object
    /// </summary>
    private void OnMouseExit()
    {
        r.material.shader = Shader.Find("Diffuse");
    }

}