using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extinguish : MonoBehaviour
{
    public int ID = 0;
    public GameObject Skin;
    public GameObject posSkin;
    private int compounded = 0;
    private GameObject Eventsystem;
    private float timer = 0.3f;
    private int _switch = 0;

    // Start is called before the first frame update
    void Start()
    {
        Eventsystem = GameObject.Find("EventSystem");
    }
    void OnCollisionStay(Collision col)
    {
        if(compounded == 0)
        {
            if (ID != 3 && col.gameObject.name.Substring(0, 3).Equals("sto"))
            {
                _switch = 1;//延时转变
            }
            else if (ID == 1 && col.gameObject.name.Substring(0, 3).Equals("meg"))
            {
                _switch = 0;
                Skin.SetActive(false);
                this.name = "stone";
                compounded = 1;
            }
            else if (ID == 2 && (col.gameObject.name.Substring(0, 3).Equals("wat") || col.gameObject.name.Substring(0, 3).Equals("pos")))
            {
                _switch = 0;
                Skin.SetActive(false);
                this.name = "stone";
                compounded = 1;
            }
            else if (ID == 1 && col.gameObject.name.Substring(0, 3).Equals("gas"))
            {
                _switch = 0;
                Destroy(col.gameObject);
                Skin.SetActive(false);
                posSkin.SetActive(true);
                this.name = "poswater";
                this.ID = 3;
            }
            else if(ID == 1 && col.gameObject.name.Substring(0, 3).Equals("pos"))
            {
                _switch = 2;//延时转变
            }
            else if (ID == 3 && col.gameObject.name.Substring(0, 3).Equals("meg"))
            {
                _switch = 0;
                GameObject c1 = Instantiate(Resources.Load<GameObject>("prefabs/gas"), this.transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                posSkin.SetActive(false);
                this.name = "stone";
                compounded = 1;
            }
            else if (ID == 3 && col.gameObject.name.Substring(0, 3).Equals("sto"))
            {
                _switch = 3;//延时转变
            }
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
                Skin.SetActive(false);
                this.name = "stone";
                _switch = 0;
                compounded = 1;
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
                Skin.SetActive(false);
                posSkin.SetActive(true);
                this.name = "poswater";
                this.ID = 3;
                _switch = 0;
            }
        }
        else if (_switch == 3)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                GameObject c1 = Instantiate(Resources.Load<GameObject>("prefabs/gas"),this.transform.position + new Vector3(0,0.5f,0), Quaternion.Euler(new Vector3(0, 0, 0)));
                posSkin.SetActive(false);
                this.name = "stone";
                _switch = 0;
                compounded = 1;
            }
        }
    }
}
