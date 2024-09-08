using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorChange : MonoBehaviour
{

    SkinnedMeshRenderer skinnedMeshRenderer;    
    // Start is called before the first frame update
    void Start()
    {
        
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer == null)
        {
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange(int colorIndex)
    {
          //Change if we wanna add another color        
    if (skinnedMeshRenderer != null)
    {
        Material material = skinnedMeshRenderer.material;

        switch (colorIndex)
        {
            case 1:
                material.color = Color.blue;
                break;
            case 2:
                material.color = Color.red;
                break;
            case 3:
                material.color = Color.green;
                break;                
            default:
                break;
        }
    }
}
}
