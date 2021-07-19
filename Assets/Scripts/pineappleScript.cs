using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pineappleScript : MonoBehaviour
{
    public GameObject EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");   
    }
    void OnCollisionStay(Collision col)
    {   
        if (col.gameObject.name.Substring(0, 3).Equals("mag"))
        {
            EventSystem.GetComponent<ControlCentre>().failed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
