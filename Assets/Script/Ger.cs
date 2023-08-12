using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Ger : MonoBehaviour
{
    public static Ger Instance {get; private set;}
    [FormerlySerializedAs("PreFab")]
    public List<GameObject> ObsPrefab;
    public float ObsInt = 1;
    public float ObsVel = 10;
    public float setx = 0;
    public Vector2 sety = new Vector2(0, 0);

    [HideInInspector]
    public int score;
    private bool isGameOver = false;

    void Awake() {if(Instance != null && Instance != this) {Destroy(this);} else {Instance = this;}}
    public bool IsGameActive() {return !isGameOver;}
    public bool IsGameOver() {return isGameOver;}
    public void EndGame() {isGameOver = true; Debug.Log("Fim de Jogo. Sua Pontuação foi: " + score);
    StartCoroutine(ReloadScene(2));}


    private IEnumerator ReloadScene(float delay) {yield return new WaitForSeconds(delay);
    string sceneName = SceneManager.GetActiveScene().name;
    SceneManager.LoadScene(sceneName);
    Debug.Log("Reload scene!");}
}