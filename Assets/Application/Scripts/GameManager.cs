using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : MonoBehaviour
{
    public bool _game_start ,_playerpos,_enemypos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButn()
    {
        _game_start = true;
    }

    public void EndStage()
    {
        if(_playerpos && _enemypos)
        {
            _enemypos = false;
            _game_start = false;
            _playerpos = false;
        }
    }

    public void EndGame()
    {
        
    }
}
