using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManageScene : MonoBehaviour
{
    public static int prevScene;
    public string nextScene;
    public string fastBack;

    void Start() {
        Debug.Log(prevScene);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(fastBack);
        }
    }
    public void changeScene() {
        //Deals with going back to options from settings
        if(prevScene == 3 && SceneManager.GetActiveScene().buildIndex == 2) {
            SceneManager.LoadScene(3);
        }
        //Deals with going back to main menu from settings
        if(prevScene == 0 && SceneManager.GetActiveScene().buildIndex == 2) {
            SceneManager.LoadScene(0);
        }
        else {
            prevScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nextScene);
        }
    }
}
