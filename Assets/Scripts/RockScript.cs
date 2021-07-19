using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public GameObject EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
    }

    void OnCollisionEnter(Collision col)
    {
        if(Mathf.Abs(this.GetComponent<Rigidbody>().velocity.x) > 3 || Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) > 1)
        {
            if (col.gameObject.name.Substring(0, 3).Equals("mon"))
            {
                col.gameObject.GetComponent<MonkeyScript>().die(1);
                EventSystem.GetComponent<ControlCentre>().failed();
            }
            else if (col.gameObject.name.Substring(0, 3).Equals("dog"))
            {
                col.gameObject.GetComponent<dogScript>().die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
