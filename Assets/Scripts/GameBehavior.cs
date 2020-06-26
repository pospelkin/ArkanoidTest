using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior instance;
    private int _scoreGame = 0;
    private int _destroyBlock = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int Score
    {
        get { return _scoreGame; }

        set { _scoreGame = value; }
    }

    public int CoundDestroyBlock
    {
        get { return _destroyBlock; }

        set { _destroyBlock = value; }
    }

}
