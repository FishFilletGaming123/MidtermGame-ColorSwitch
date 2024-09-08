using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyColor 
    {
        Red,
        Blue,
        Green
    }

    public EnemyColor enemyColor;    
    public float moveSpeed;

    private Transform playerTransform;  

    public GameObject colorChangeObject; 
    private EnemyColorChange eColorChange;

    private Color targetColor = Color.white;     

    void Start()
    {
        int randomColorIndex = Random.Range(0, 3);
        enemyColor = (EnemyColor)randomColorIndex;

        if (colorChangeObject != null)
        {
            eColorChange = colorChangeObject.GetComponent<EnemyColorChange>();
        }

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

    }

    void Update()
{
    if (playerTransform != null)
    {
        ColorUpdate();             
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }
    }
}


    void OnTriggerEnter(Collider other)
    {
        Renderer otherRenderer = other.gameObject.GetComponent<Renderer>();
        if (otherRenderer != null)
        {         
            if (otherRenderer.material.color == targetColor)
            {
                GameManager.instance.AddKill();                   
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }            
        }
    }

    void ColorUpdate()
    {
        switch (enemyColor)
        {
            case EnemyColor.Blue:
                targetColor = Color.blue;
                if (eColorChange != null)
                {
                    eColorChange.ColorChange(1);
                }
                break;
            case EnemyColor.Red:
                targetColor = Color.red;
                if (eColorChange != null)
                {
                    eColorChange.ColorChange(2);
                }         
                break;                       
            case EnemyColor.Green:
                targetColor = Color.green;
                if (eColorChange != null)
                {
                    eColorChange.ColorChange(3);
                }                           
                break;
        }
    }
}
