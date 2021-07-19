using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogScript : MonoBehaviour
{
    public int direction = -1;
    public GameObject Monkey;
    public float timer = 0;
    public float dieTimer = 0;
    public float totaltimer = 4;
    public int condition = 1;
    private Animator dogAnimator;
    private int flag = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        dogAnimator = this.GetComponent<Animator>();
        Monkey = GameObject.Find("monkey");
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name.Substring(0, 3).Equals("meg"))
        {
            die();
        }
        else if (col.gameObject.name.Substring(0, 3).Equals("gas"))
        {
            die();
        }
        else if (col.gameObject.name.Substring(0, 3).Equals("pos"))
        {
            die();
        }
    }
    public void die()
    {
        flag = 0;
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        dogAnimator.SetBool("isDying", true);
        print("dogDie");
    }

    public void changeCondition(int i)
    {
        condition += i;
        Walk(condition);
    }

    public void Walk(int x)
    {
        if (x > 0)
        {
            dogAnimator.SetBool("isRuning", false);
            flag = 1;
        }
        else
        {
            dogAnimator.SetBool("isRuning", true);
            flag = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (flag == -1)
        {
            if (timer < (totaltimer - Monkey.GetComponent<MonkeyScript>().timer))
            {
                timer += Time.deltaTime;
                this.GetComponent<Rigidbody>().velocity = new Vector3(direction*5f, this.GetComponent<Rigidbody>().velocity.y, 0);
            }

        }
        else if (flag == 1)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, 0);
        }

        else if(flag == 0)
        {
            if(dieTimer < 2)
            {
                dieTimer += Time.deltaTime;
            }
            else
            {
                dogAnimator.SetBool("isDead", true);
            }
        }
    }
}