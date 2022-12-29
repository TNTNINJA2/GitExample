using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public Text scoreText;
    private int score;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject statistics;
    private float timeSurvived = 0;
    private float acceleratorKills = 0;
    private float shooterKills = 0;
    private float velocityKills = 0;
    private float totalKills = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSurvived += Time.deltaTime;
    }

    public void IncreaseScore(int amount)
    {
        // increas the score by the amount and updat the score text ui
        score += amount;
        scoreText.text = score.ToString();
    }

    public void IncreaseKillCount(string enemyTypeKilled)
    {
        enemyTypeKilled = enemyTypeKilled.Replace("(Clone)", "");
        Debug.Log(enemyTypeKilled + " was killed");
        totalKills++;
        if (enemyTypeKilled == "Accelerating Enemy")
        {
            acceleratorKills++;
        } 
        if (enemyTypeKilled == "Shooter Enemy")
        {
            shooterKills++;
        }
        if (enemyTypeKilled == "Velocity Enemy")
        {
            velocityKills++;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {

       statistics.GetComponent<Text>().text =
            "Statistics: \n" +
            "Score: " + score + "\n" +
            "Time Survived: " + timeSurvived + "\n" +
            "Accelerator Enemty Kills: " + acceleratorKills + "\n" +
            "Shooter Enemty Kills: " + shooterKills + "\n" +
            "Velocity Enemty Kills: " + velocityKills + "\n" +
            "Total Kills: " + totalKills;

        gameOverScreen.SetActive(true);


    }
}
