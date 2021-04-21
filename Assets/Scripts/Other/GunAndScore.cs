using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunAndScore : MonoBehaviour
{
    public int EnemiesKilled;
    public float damageDone;
    public int highScore;

    public bool resetHighscoreOnPlay = false;

    public Text m_score;
    public Text m_killedAMNT;
    public Text m_highScore;

    void Start()
    {
        if (resetHighscoreOnPlay == true)
        {
            ResetHighScore();
        }

        EnemiesKilled = 0;
        m_highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        m_score.text = damageDone.ToString("#");
        m_killedAMNT.text = EnemiesKilled.ToString();

        if (damageDone > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(damageDone));
            m_highScore.text = Mathf.RoundToInt(damageDone).ToString();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
