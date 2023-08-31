using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleGameState : MonoBehaviour
{
    public GameObject enemyHandler;

    enum gamestate { 
        init,
        spawn_enemies,
        tease_boss,
        spawn_enemies_again,
        spawn_boss
    }

    bool enemiesSpawned=false;

    float stateChangeTime; 

    gamestate statetracker;

    bool GameLost =false;

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
    public void PlayerLostStart()
    {
        StartCoroutine(PlayerLost());
    }
     public IEnumerator PlayerLost() {

            GameLost = true;
            //TextMeshPro losttext = gameObject.AddComponent<TextMeshPro>();
            //losttext.text = "You Lose Gamer!, Press Enter to Try again!";
            //losttext.color = Color.red;
            //losttext.transform.position = Vector3.zero; 
            yield return waitForKeyPress(KeyCode.Return); // wait for this function to return
            //losttext.color = Color.green;
            //SceneManager.LoadScene(sceneName: "Title");
            //Resources.UnloadUnusedAssets();
            //AsyncOperation ao = SceneManager.UnloadSceneAsync(sceneName: "SampleScene");
            //yield return ao;


    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }

        
    }


    void updatestate() {
        if (statetracker < gamestate.spawn_boss && Time.fixedTime - 2 >= stateChangeTime && enemyHandler.GetComponent<EnemyHandler>().allenemiesDead())
        {
            statetracker++;
            stateChangeTime = Time.fixedTime;
            enemiesSpawned = false;
        }
        else if (statetracker == gamestate.spawn_boss && Time.fixedTime - 5 >= stateChangeTime && enemyHandler.GetComponent<EnemyHandler>().allenemiesDead())
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
                        enemyHandler.GetComponent<EnemyHandler>().spawnEnemy1(); 
                    enemiesSpawned = true;
                    return;
                }
                else
                    return;
            case gamestate.tease_boss:
                if (!enemiesSpawned)
                {
                    enemyHandler.GetComponent<EnemyHandler>().spawnBoss1();
                    enemiesSpawned = true;
                    return;
                }
                else
                    return;
                
            case gamestate.spawn_enemies_again:
                if (!enemiesSpawned)
                {
                    for (int i = 0; i < 3; ++i)
                        enemyHandler.GetComponent<EnemyHandler>().spawnEnemy1();
                    enemiesSpawned = true;
                    return;
                }
                else
                    return;
            case gamestate.spawn_boss:
                if (!enemiesSpawned)
                {
                    enemyHandler.GetComponent<EnemyHandler>().spawnBoss1();
                    enemiesSpawned = true;
                    return;
                }
                else
                    return;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        if (GameLost)
        {
            return;
        }
        updatestate();
        performstatebehavior();

    }
}
