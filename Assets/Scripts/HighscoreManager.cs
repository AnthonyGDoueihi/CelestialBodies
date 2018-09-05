using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour {

    public Text scoreName1;
    public Text scoreName2;
    public Text scoreName3;
    public Text scoreName4;
    public Text scoreName5;

    public Text highscore1;
    public Text highscore2;
    public Text highscore3;
    public Text highscore4;
    public Text highscore5;

    public GameObject areYouSure;


    // Use this for initialization
    void Start () {

        GetHighscores();
        if (areYouSure == null) { return; }
        areYouSure.SetActive(false); 
    }

    public void AreYouSure()
    {
        if (areYouSure == null) { return; }

        areYouSure.SetActive(true);
    }



    public void ClearHighscores()
    {
        PlayerPrefsManager.ClearHighscores();

        GetHighscores();

        if (areYouSure == null) { return; }

        areYouSure.SetActive(false);
    }

    void GetHighscores()
    {
        if (scoreName1 == null || scoreName2 == null || scoreName3 == null || scoreName4 == null || scoreName5 == null ||
            highscore1 == null || highscore2 == null || highscore3 == null || highscore4 == null || highscore5 == null)
        { return; }

        scoreName1.text = PlayerPrefsManager.GetScoreName(0);
        scoreName2.text = PlayerPrefsManager.GetScoreName(1);
        scoreName3.text = PlayerPrefsManager.GetScoreName(2);
        scoreName4.text = PlayerPrefsManager.GetScoreName(3);
        scoreName5.text = PlayerPrefsManager.GetScoreName(4);

        highscore1.text = PlayerPrefsManager.GetHighscores(0).ToString();
        highscore2.text = PlayerPrefsManager.GetHighscores(1).ToString();
        highscore3.text = PlayerPrefsManager.GetHighscores(2).ToString();
        highscore4.text = PlayerPrefsManager.GetHighscores(3).ToString();
        highscore5.text = PlayerPrefsManager.GetHighscores(4).ToString();
    }
}
