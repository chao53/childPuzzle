using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapScript : MonoBehaviour
{
    public GameObject arrows;
    private bool _switch = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_switch)
        {
            arrows.GetComponent<ArrowScript>().shoot();
            _switch = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
