using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{
    public GameObject levelManager;
    public string next;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("levelManager");
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        levelManager.GetComponent<levelManagerScript>().changeNextLevel(next);
        levelManager.GetComponent<levelManagerScript>().loadNext();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
