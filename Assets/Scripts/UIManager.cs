using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Sprite[] liveSprites;
    [SerializeField] private Image livesImg;
    [SerializeField] private GameObject gameOver;

    void Start(){
        if (scoreText == null)
            scoreText = GameObject.FindWithTag("Score").GetComponent<TMP_Text>();
    }

    public void UpdateLives(int currLive){
        livesImg.sprite = liveSprites[currLive];
    }
    
    public void UpdateScore(int value){
        scoreText.text = "Score: " + value;
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine(true));
    }

    private IEnumerator GameOverFlickerRoutine(bool isActive){
        while (true){
            yield return new WaitForSeconds(1f);
            isActive = !isActive;
            gameOver.SetActive(isActive);
        }
    }

}
