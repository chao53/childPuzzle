using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCentre : MonoBehaviour
{
    public GameObject passPanel;
    public GameObject failedPanel;
 
    private float timer = 2;
    private int _switch = 0;
    private bool settle = false;
    // Start is called before the first frame update
    void Start()
    {

        passPanel = GameObject.Find("PassPanel");
        failedPanel = GameObject.Find("failedPanel");
        passPanel.SetActive(false);
        failedPanel.SetActive(false);
    }

    public void Pass()
    {
        if (!settle)//ÊÇ·ñÈ·¶¨
        {
            _switch = 1;
        }
    }
    public void failed()
    {
        if(!settle)
        {
            timer = 2;
            _switch = 2;
            print("failed");
            settle = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_switch == 1)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                passPanel.SetActive(true);
            }
        }
        else if(_switch == 2)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                failedPanel.SetActive(true);
            }
        }
    }
}
