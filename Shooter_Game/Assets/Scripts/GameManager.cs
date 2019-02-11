using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timeBetweenMovInc;
    private float nextInc;
    public float enemySpeed=150f;
    public float bulletSpeed=450f;  
    private Spawner spawner;
   [HideInInspector]public int dieAreaCount;
    public Text scoreText;
   [HideInInspector] public int scorePoint;
    [SerializeField]
    private GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        if (instance==null)
        {
            instance = this;
        }
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextInc)
        {
            enemySpeed++;
            bulletSpeed += 0.5f;   
            nextInc = Time.time + timeBetweenMovInc;
        }
        spawner.SpawnWave();
        ScoreShower();
    }


    public void SoundPlayer(GameObject[] soundEffects)
    {
        Instantiate(soundEffects[Random.Range(0,soundEffects.Length)]);
    }

    public void GameOver()
    {
        Time.timeScale = 0.1f;
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
    }

    public void ScoreShower()
    {
        scoreText.text = "Score: " + scorePoint.ToString();
    }

    public void GameRestart()
    {
        Time.timeScale = 1;      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }



}
