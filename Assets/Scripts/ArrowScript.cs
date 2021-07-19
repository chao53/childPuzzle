using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject EventSystem;
    private Vector3 pos;
    private int _switch = 0;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        pos = this.transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Substring(0, 3).Equals("mon"))
        {
            col.gameObject.GetComponent<MonkeyScript>().die(1);
            EventSystem.GetComponent<ControlCentre>().failed();
        }
        else if(col.gameObject.name.Substring(0, 3).Equals("dog"))
        {
            col.gameObject.GetComponent<dogScript>().die();
        }
        if(!col.gameObject.name.Substring(0, 3).Equals("gas"))
        {
            Destroy(gameObject);
        }     
    }

    public void shoot()
    {
        _switch = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(_switch == 1)
        {
            if(timer < 0.8f)
            {
                timer += Time.deltaTime;
                this.transform.position = pos + new Vector3(0, -30*timer, 0);
            }
        }
    }
}
