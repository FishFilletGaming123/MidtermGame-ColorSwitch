using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColorChange : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    void Start()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    public void UpdateBulletColor(int colorIndex)
    {
        if (meshRenderer != null)
        {
            Material material = meshRenderer.sharedMaterial;
            switch (colorIndex)
            {
                case 0:
                    material.color = Color.blue;
                    break;
                case 1:
                    material.color = Color.red;
                    break;
                case 2:
                    material.color = Color.green;
                    break;                    
                default:
                    break;
            }        
        }
    }
}
