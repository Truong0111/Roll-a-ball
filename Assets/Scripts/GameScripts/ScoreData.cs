using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ScoreData
{
    public int highScore;

    public ScoreData(GameController gc)
    {
        highScore = gc.m_highScore;
    }

    public ScoreData(MenuController mc)
    {
        highScore = mc.m_highScore;
    }
}
