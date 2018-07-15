using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text gameOver;
    public Text higherScore;
    public Text playerScore;
    public Text lowerScore;
    public Text higherName;
    public Text playerName;
    public Text lowerName;
    public GameObject inputField;
    public InputField playerInput;
    public GameObject MainMenu;
    public GameObject Highscore;
    private string inputName;

    private float finishedScore;
    
    // Use this for initialization
    void Start () {
        inputName = null;
        gameOver.enabled = false;
        higherScore.enabled = false;
        playerScore.enabled = false;
        lowerScore.enabled = false;
        higherName.enabled = false;
        playerName.enabled = false;
        lowerName.enabled = false;
        inputField.SetActive(false);
        MainMenu.SetActive(false);
        Highscore.SetActive(false);

        finishedScore = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameLost(float score)
    {
        gameOver.enabled = true;
        finishedScore = score;
        if (IsHighscore(finishedScore))
        {
            inputField.SetActive(true);
                        
        }
        else
        {
            NoChange();
        }
    }

    bool IsHighscore(float score)
    {
        
        float lowestHighscore = PlayerPrefsManager.GetHighscores(4);
        if (score < lowestHighscore)
        {
            return false;
        }
        else { return true; }
    }

    public void ChangeScore()
    {
        inputName = playerInput.text;
        inputField.SetActive(false);

        higherScore.enabled = true;
        playerScore.enabled = true;
        lowerScore.enabled = true;
        higherName.enabled = true;
        playerName.enabled = true;
        lowerName.enabled = true;

        int highScorePlace = 0;
        for (int i= 0; i < 5; i++ ){
            float testScore = PlayerPrefsManager.GetHighscores(i);
            if (testScore < finishedScore)
            {
                highScorePlace = i;
                break;
            }
        }

        for (int i = 4; i > highScorePlace; i--)
        {
            PlayerPrefsManager.SetHighscores(i, PlayerPrefsManager.GetHighscores(i - 1));
            PlayerPrefsManager.SetScoreName(i, PlayerPrefsManager.GetScoreName(i - 1));
        }

        PlayerPrefsManager.SetHighscores(highScorePlace, finishedScore);
        PlayerPrefsManager.SetScoreName(highScorePlace, inputName);

        if (highScorePlace == 4)
        {
            higherScore.text = PlayerPrefsManager.GetHighscores(highScorePlace -2).ToString();
            playerScore.text = PlayerPrefsManager.GetHighscores(highScorePlace -1).ToString();
            lowerScore.text = PlayerPrefsManager.GetHighscores(highScorePlace).ToString();
            higherName.text = PlayerPrefsManager.GetScoreName(highScorePlace -2);
            playerName.text = PlayerPrefsManager.GetScoreName(highScorePlace -1);
            lowerName.text = PlayerPrefsManager.GetScoreName(highScorePlace);
        }
        else if (highScorePlace == 0)
        {
            
            higherScore.text = PlayerPrefsManager.GetHighscores(highScorePlace).ToString();
            playerScore.text = PlayerPrefsManager.GetHighscores(highScorePlace +1).ToString();
            lowerScore.text = PlayerPrefsManager.GetHighscores(highScorePlace + 2).ToString();
            higherName.text = PlayerPrefsManager.GetScoreName(highScorePlace);
            playerName.text = PlayerPrefsManager.GetScoreName(highScorePlace +1);
            lowerName.text = PlayerPrefsManager.GetScoreName(highScorePlace + 2);

        }
        else
        {
            higherScore.text = PlayerPrefsManager.GetHighscores(highScorePlace -1).ToString();
            playerScore.text = PlayerPrefsManager.GetHighscores(highScorePlace).ToString();
            lowerScore.text = PlayerPrefsManager.GetHighscores(highScorePlace +1).ToString();
            higherName.text = PlayerPrefsManager.GetScoreName(highScorePlace -1);
            playerName.text = PlayerPrefsManager.GetScoreName(highScorePlace);
            lowerName.text = PlayerPrefsManager.GetScoreName(highScorePlace +1);
        }

        MainMenu.SetActive(true);
        Highscore.SetActive(true);

    }

    public void OnValueChange()
    {
        playerInput.text = playerInput.text.ToUpper();
    }

    void NoChange()
    {
        higherScore.enabled = true;
        playerScore.enabled = true;
        lowerScore.enabled = true;
        higherName.enabled = true;
        playerName.enabled = true;
                

        higherScore.text = PlayerPrefsManager.GetHighscores(3).ToString();
        playerScore.text = PlayerPrefsManager.GetHighscores(4).ToString();
        lowerScore.text = finishedScore.ToString();
        higherName.text = PlayerPrefsManager.GetScoreName(3);
        playerName.text = PlayerPrefsManager.GetScoreName(4);

        MainMenu.SetActive(true);
        Highscore.SetActive(true);
    }
}
