using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Sprite[] liveSprites;
    [SerializeField] private Image livesImg;

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

}
