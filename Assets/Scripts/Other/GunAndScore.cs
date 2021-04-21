using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunAndScore : MonoBehaviour
{
    public int EnemiesKilled;
    public Text m_killedAMNT;

    void Start()
    {
        EnemiesKilled = 0;
    }

    void Update()
    {
        m_killedAMNT.text = EnemiesKilled.ToString();
    }
}
