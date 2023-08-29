using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleGameState : MonoBehaviour
{
    public EnemyHandler enemyHandler;

    enum gamestate { 
        init,
        spawn_enemies,
        tease_boss,
        spawn_enemies_again,
        spawn_boss
    }

    bool enemiesSpawned;

    float stateChangeTime; 

    gamestate statetracker;

    // Start is called before the first frame update
    void Start()
    {
       statetracker = gamestate.init;
        stateChangeTime = Time.fixedTime;
    }

    public void Quit()
    {
    #if UNITY_STANDALONE
        Application.Quit();
    #endif
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }


    void updatestate() {
        if (statetracker < gamestate.spawn_boss && Time.fixedTime - 5 >= stateChangeTime && enemyHandler.allenemiesDead())
        {
            statetracker++;
            stateChangeTime = Time.fixedTime;
            enemiesSpawned = false;
        }
        else if (statetracker == gamestate.spawn_boss && Time.fixedTime - 5 >= stateChangeTime && enemyHandler.allenemiesDead())
        {
            Quit();
        }
    }
    void performstatebehavior()
    {
        switch (statetracker) { 
            case gamestate.init:
                return;
            case gamestate.spawn_enemies:
                if (!enemiesSpawned)
                {
                    for (int i = 0; i < 6; ++i)
                        enemyHandler.spawnEnemy1();
                    enemiesSpawned = true;
                    return;
                }
                else
                    return;
            case gamestate.tease_boss: 
                return;
            case gamestate.spawn_enemies_again:
                return;
            case gamestate.spawn_boss:
                return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        updatestate();
        performstatebehavior();

    }
}
