using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class poleScript : MonoBehaviour, IPointerClickHandler//IPointerDownHandler, IDragHandler, IPointerUpHandler
{ 
    public GameObject EventSystem;
    public GameObject Monkey;
    public float critical = 0;
    public float direction = 1;
    public bool canBack = true;
    private bool canClick = true;
    private float timer = 0;
    private Vector3 pos;
    private float len;
    private float speed = 2.5f;
    private int flag = -1;
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        Monkey = GameObject.Find("monkey");
        pos = this.transform.position;
        len = this.transform.localScale.y;
        speed = canBack ? 2f : 20f;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (canClick)
        {
            if (Monkey.GetComponent<MonkeyScript>().timer < critical)
            {
                Monkey.GetComponent<MonkeyScript>().changeCondition(flag);
            }
            flag *= -1;
            if (!canBack)
            {
                canClick = false;
            }
        }
    }

    void Update()
    {
        if(flag == 1)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime;
            }
            
        }else if(flag == -1)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
        }
        this.transform.position = pos + new Vector3(speed * len * timer * Mathf.Cos(Mathf.PI*direction), speed * len * timer * Mathf.Sin(Mathf.PI*direction), 0);
    }
}