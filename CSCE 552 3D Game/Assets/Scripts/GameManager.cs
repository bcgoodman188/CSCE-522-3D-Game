using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();
    public static bool isLoaded = false;
    public GameObject pauseMenu;
    public GameObject saveButton;
    public bool gamePaused = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI healthText;

    public static int health = 100;
    public static int score = 0;
    public float timerLeft;
    public bool timerOn = false;
    public int healthSave;
    public int scoreSave;
    public int waveSave;
    //public static int timerSecOne = 0;
    //public static int timerSecTwo = 0;
    public static int wave = 0;
    void Start() {
        if(isLoaded == true) {
            LoadGameState();
            isLoaded = false;
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Tab) && timerOn == false) {
            wave++;
            timerLeft = 20;
            timerOn = true;
            showSpawners();
            saveButton.SetActive(false);
        }
        if(timerOn) {
            if(timerLeft > 0){
                timerLeft -= Time.deltaTime;
                updateTime(timerLeft);
            }
            else {
                healthSave = health;
                scoreSave = score;
                waveSave = wave;
                timerLeft = 0f;
                timerOn = false;
                hideSpawners();
                saveButton.SetActive(true);
            }
        }
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
    public void updateTime(float time) {
        time += 1;

        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format(" Timer: {0:00}:{1:00}", min, sec);
    }
    public void SaveGameState() {
        GameSave.SaveGameState(this);
    }
    public void LoadGameState() {
        GameData gameData = GameSave.LoadGameState();

        health = gameData.health;
        wave = gameData.wave;
        score = gameData.score;
    }
    void showSpawners() {
        for(int i = 0; i < spawners.Count; i++) {
            spawners[i].SetActive(true);
        }
    }
    void hideSpawners() {
        for(int i = 0; i < spawners.Count; i++) {
            spawners[i].SetActive(false);
        }
    }
}
