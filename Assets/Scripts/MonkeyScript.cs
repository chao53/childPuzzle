using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyScript : MonoBehaviour
{
    public GameObject EventSystem;
    public bool canMove = true;
    public float timer = 0;//猴子行进进度。
    public float timer2 = 0;//判断时间
    public float totalTimer = 4;
    public int condition = 1;
    public GameObject grape;
    public bool grapeIsBox = true;
    private Animator grapeAnimator;
    private Animator monkeyAnimator;
    private Vector3 pos;
    private int flag = 1;
    // Start is called before the first frame update  hhh
    void Start()
    {
        grape = GameObject.Find("grape");
        grapeAnimator = grape.GetComponent<Animator>();
        monkeyAnimator = this.GetComponent<Animator>();
        EventSystem = GameObject.Find("EventSystem");
        pos = this.transform.position;
    }

    public void die(int way)
    {
        monkeyAnimator.SetBool("isDying" + way, true);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 0);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        flag = 0;
        print("monkeyDie");
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name.Substring(0, 3).Equals("gra"))
        {
            if (grapeIsBox)
            {
                grapeAnimator.SetBool("open", true);
            } 
            monkeyAnimator.SetBool("happy", true);
            EventSystem.GetComponent<ControlCentre>().Pass();
        }
        else if (col.gameObject.name.Substring(0, 3).Equals("meg"))
        {
            die(1);
            EventSystem.GetComponent<ControlCentre>().failed();
        }
        else if (col.gameObject.name.Substring(0, 3).Equals("dog"))
        {
            die(2);
            EventSystem.GetComponent<ControlCentre>().failed();
        }
        else if(col.gameObject.name.Substring(0, 3).Equals("gas"))
        {
            die(2);
            EventSystem.GetComponent<ControlCentre>().failed();
        }
        else if (col.gameObject.name.Substring(0, 3).Equals("pos"))
        {
            die(1);
            EventSystem.GetComponent<ControlCentre>().failed();
        }
    }

    public void changeCondition(int i)
    {
        condition += i;
        Walk(condition);
    }
    public void Walk(int x)
    {
        
        if(x > 0)
        {
            monkeyAnimator.SetBool("isRuning", false);
            flag = 1;
        }
        else
        {
            monkeyAnimator.SetBool("isRuning",true);
            flag = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -100)
        {
            EventSystem.GetComponent<ControlCentre>().failed();
        }
        if (flag == -1)
        {
            if (timer < totalTimer)
            {
                timer += Time.deltaTime;
                if (canMove)
                {
                    this.GetComponent<Rigidbody>().velocity = new Vector3(5f, this.GetComponent<Rigidbody>().velocity.y, 0);
                }               
            }
            else
            {
                timer2 += Time.deltaTime;
                if(timer2 > 5)
                {
                    EventSystem.GetComponent<ControlCentre>().failed();
                }
                if (canMove)
                {
                    this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 0);
                }                 
            }
            
        }
        if(flag == 1)
        {
            if (canMove)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 0);
            }              
        }
        if(flag == 0)
        {

        }
    }
}
