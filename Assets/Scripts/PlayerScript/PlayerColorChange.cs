using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public BulletColorChange bulletColorChange;
    SkinnedMeshRenderer skinnedMeshRenderer;
    private Color[] colors = { Color.blue, Color.red, Color.green};
    private int colorIndex = 0;

    void Start()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
        {
            skinnedMeshRenderer.material.color = colors[colorIndex];
        }
    }

    void Update()
    {
    }

    void OnMouseDown() 
    {
        if (skinnedMeshRenderer != null)
        {
            skinnedMeshRenderer.material.color = colors[colorIndex];
            UpdateBulletColor();
            colorIndex = (colorIndex + 1) % colors.Length;            
        }
    }

    void UpdateBulletColor()
    {
        if (bulletColorChange != null)
        {
            bulletColorChange.UpdateBulletColor(colorIndex);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemy"))
        {
            GameManager.instance.DeathScreen();               
            Destroy(gameObject);
        }
    }
}
