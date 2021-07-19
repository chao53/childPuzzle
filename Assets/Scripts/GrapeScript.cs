using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeScript : MonoBehaviour
{
    public GameObject EventSystem;
    public GameObject Monkey;
    private Animator monkeyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        Monkey = GameObject.Find("monkey");
        monkeyAnimator = Monkey.GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
         if(col.gameObject.name.Substring(0, 3).Equals("meg"))
        {
            monkeyAnimator.SetBool("sad", true);
            EventSystem.GetComponent<ControlCentre>().failed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
