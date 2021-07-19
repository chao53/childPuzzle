using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManagerScript : MonoBehaviour
{
    public string nextLevel = "level1";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeNextLevel(string str)
    {
        nextLevel = str;
    }

    public void loadNext()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadSceneAsync("loadingScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
