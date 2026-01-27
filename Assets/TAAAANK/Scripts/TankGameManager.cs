using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankGameManager : MonoBehaviour
{

    [SerializeField] GameObject titlePanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool debug = false;

    static TankGameManager instance;
    public static TankGameManager Instance {  
        get {
            if (instance == null) instance = FindFirstObjectByType<TankGameManager>();
            return instance; 
        } 
    }

    public int Score { get; set; } = 0;

    void Start()
    {
        Time.timeScale = (debug) ? 1.0f: 0.0f;
    }
    void Update()
    {
        scoreText.text = Score.ToString($"Score: {Score}");
        titlePanel.SetActive(!debug);
    }

    public void OnGameStart()
    {
        titlePanel.SetActive(false);
        Time.timeScale = 1.0f;

    }
    public void OnGameWin()
    {
        Time.timeScale = 0.0f;
        
    }
    public void OnGameOver()
    {
        StartCoroutine(ResetGameCR(2.0f));
    }

    IEnumerator ResetGameCR(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
