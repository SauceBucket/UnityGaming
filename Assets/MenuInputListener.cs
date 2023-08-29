using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInputListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKey(KeyCode.Return))
            {
            
            SceneManager.LoadScene(sceneName:"SampleScene");
            SceneManager.UnloadSceneAsync(sceneName: "Title");
            }

        
    }
}
