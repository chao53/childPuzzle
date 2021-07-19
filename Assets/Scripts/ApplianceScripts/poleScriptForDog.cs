using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class poleScriptForDog : MonoBehaviour, IPointerClickHandler
{
    public GameObject Dog;
    public float critical;
    private int flag = -1;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Dog.GetComponent<dogScript>().timer < critical)
        {
            Dog.GetComponent<dogScript>().changeCondition(flag);
        }
        flag *= -1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
