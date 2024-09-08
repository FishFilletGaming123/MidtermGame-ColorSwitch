using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public static GameManager instance;
    public TextMeshProUGUI[] killText;

    private int kill;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
          
    }

    void Update()
    {
        foreach (TextMeshProUGUI text in killText)
        {
            text.text = kill.ToString();
        }
    }

    // Update is called once per frame
    public void AddKill()
    {
        kill++;
    }

    public void DeathScreen()
    {
        GameOverUI.SetActive(true);
    }
    public void RetryGame()
    {
        kill = 0;
        GameOverUI.SetActive(false);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }

}
