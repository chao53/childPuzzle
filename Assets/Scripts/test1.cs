using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    private GameObject c1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c1 = Instantiate(Resources.Load<GameObject>("prefabs/water"), new Vector3(-5.355364f, 54.15107f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
