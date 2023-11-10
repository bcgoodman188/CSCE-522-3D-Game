using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool gamePaused = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI healthText;
    public static int score = 0;
    public static int timerMin = 2;
    public static int timerSecOne = 0;
    public static int timerSecTwo = 0;
    public static int wave = 0;
    public static int health = 100;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gamePaused == true) {
                Resume();
            }
            else {
                VacuumGun.canFire = false;
                Pause();
                Cursor.lockState = CursorLockMode.None;
            }

        }
        scoreText.text = "Score: " + score.ToString();
        timerText.text = "Timer: " + timerMin.ToString() + ":" + timerSecOne.ToString() + "" + timerSecTwo.ToString();
        waveText.text = "Wave: " + wave.ToString();
        healthText.text = "Health: " + health.ToString();
    }
    public void Resume() {
        VacuumGun.canFire = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gamePaused = false;
    }
    void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void Quit() {
        VacuumGun.canFire = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
}
