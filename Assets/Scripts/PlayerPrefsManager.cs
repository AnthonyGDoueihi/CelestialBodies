using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string HIGHSCORE1_KEY = "highscore1_key";
    const string HIGHSCORE2_KEY = "highscore2_key";
    const string HIGHSCORE3_KEY = "highscore3_key";
    const string HIGHSCORE4_KEY = "highscore4_key";
    const string HIGHSCORE5_KEY = "highscore5_key";

    static string[] highscores =    {
        HIGHSCORE1_KEY, HIGHSCORE2_KEY, HIGHSCORE3_KEY, HIGHSCORE4_KEY, HIGHSCORE5_KEY
    };

    const string SCORENAME1_KEY = "scorename1_key";
    const string SCORENAME2_KEY = "scorename2_key";
    const string SCORENAME3_KEY = "scorename3_key";
    const string SCORENAME4_KEY = "scorename4_key";
    const string SCORENAME5_KEY = "scorename5_key";

    static string[] scorenames =    {
        SCORENAME1_KEY, SCORENAME2_KEY, SCORENAME3_KEY, SCORENAME4_KEY, SCORENAME5_KEY
    };

    public static float GetHighscores(int number)
    {
        return PlayerPrefs.GetFloat(highscores[number]);
    }

    public static void SetHighscores(int number, float highscore)
    {
        PlayerPrefs.SetFloat(highscores[number], highscore);
    }

    public static string GetScoreName(int number)
    {
        return PlayerPrefs.GetString(scorenames[number]);
    }

    public static void SetScoreName(int number, string name)
    {
        PlayerPrefs.SetString(scorenames[number], name);
    }

    public static void ClearHighscores()
    {
        PlayerPrefs.DeleteAll();

        DefaultHighscores();
    }

    public static void DefaultHighscores()
    {

        if (!PlayerPrefs.HasKey(HIGHSCORE1_KEY))
        {
            PlayerPrefs.SetFloat(highscores[0], 250);

        }
        if (!PlayerPrefs.HasKey(HIGHSCORE2_KEY))
        {
            PlayerPrefs.SetFloat(highscores[1], 200);

        }
        if (!PlayerPrefs.HasKey(HIGHSCORE3_KEY))
        {
            PlayerPrefs.SetFloat(highscores[2], 150);

        }
        if (!PlayerPrefs.HasKey(HIGHSCORE4_KEY))
        {
            PlayerPrefs.SetFloat(highscores[3], 100);

        }
        if (!PlayerPrefs.HasKey(HIGHSCORE5_KEY))
        {
            PlayerPrefs.SetFloat(highscores[4], 50);

        }
        if (!PlayerPrefs.HasKey(SCORENAME1_KEY))
        {
            PlayerPrefs.SetString(scorenames[0], "AAA");

        }
        if (!PlayerPrefs.HasKey(SCORENAME2_KEY))
        {
            PlayerPrefs.SetString(scorenames[1], "BBB");

        }
        if (!PlayerPrefs.HasKey(SCORENAME3_KEY))
        {
            PlayerPrefs.SetString(scorenames[2], "CCC");

        }
        if (!PlayerPrefs.HasKey(SCORENAME4_KEY))
        {
            PlayerPrefs.SetString(scorenames[3], "DDD");

        }
        if (!PlayerPrefs.HasKey(SCORENAME5_KEY))
        {
            PlayerPrefs.SetString(scorenames[4], "EEE");

        }
    }


}
