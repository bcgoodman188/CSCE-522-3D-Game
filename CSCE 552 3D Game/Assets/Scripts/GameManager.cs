using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    SpawnEnemy spawnEnemy;
    public List<GameObject> spawners = new List<GameObject>();
    public static bool isLoaded = false;
    public GameObject pauseMenu;
    public GameObject saveButton;
    public GameObject ammoDropCrate;
    public Transform ammoDropSpawnPoint;
    public bool gamePaused = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI waveText;
    //public TextMeshProUGUI healthText;

    public Slider slider;

    public AudioSource nextWaveSound;

    public static int health; //= 100;
    public static int score; //= 0;
    public static float scoreDecay = 0;
    public float timerLeft;
    public static bool timerOn = false;
    public int healthSave;
    public int scoreSave;
    public int waveSave;
    public int winGame;
    //public static int timerSecOne = 0;
    //public static int timerSecTwo = 0;
    public static int wave; //= 0;
    void Start() {
        slider.value = health;
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        if(isLoaded == true) {
            LoadGameState();
            isLoaded = false;
        }
        else {
            wave = 0;
            health = 100;
            score = 0;
        }
    }

    void Update() {
        scoreDecay += Time.deltaTime;
        if(timerOn == false && scoreDecay >= 5f && score > 0) {
            scoreDecay = 0f;
            score -= 10;
        }
        if(score > HighScoreSave.highScore) {
            HighScoreSave.highScore = score;
        }
        if(Input.GetKeyDown(KeyCode.Tab) && timerOn == false) {
            nextWaveSound.Play();
            wave++;
            //Check if game is over
            if(wave == winGame) {
                score = score + 5000;
                HighScoreSave.highScore = score;
                timerLeft = 0;
                SceneManager.LoadScene(5);
                Cursor.lockState = CursorLockMode.None;
            }
            timerLeft = 20;
            timerOn = true;
            showSpawners();
            //spawnEnemy.startSpawning();
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
                //hideSpawners();
                saveButton.SetActive(true);
                //hideSpawners();
                Instantiate(ammoDropCrate, ammoDropSpawnPoint.position, ammoDropSpawnPoint.rotation);
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
        slider.value = health;
        scoreText.text = "Score: " + score.ToString();
        waveText.text = "Wave: " + wave.ToString();
        //healthText.text = "Health: " + health.ToString();

        if(health <= 0) {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(6);
        }
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
        healthSave = health;
        waveSave = wave;
        scoreSave = score;
        GameSave.SaveGameState(this);
        
        Debug.Log("health is: " + health);
        Debug.Log("wave is: " + wave);
        Debug.Log("score is: " + score);
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
