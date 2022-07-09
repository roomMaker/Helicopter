using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingControl : MonoBehaviour
{

    Rigidbody _rb;
    float speed = 0f;
    MyInput _mI;
    public GameObject Wings;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mI = GetComponent<MyInput>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (_mI.EngineOn == true)
        {
            speed += 0.002f;
            Wings.transform.Rotate(0, speed, 0);
            if (speed > 4)
                speed = 4;
        }
        if(_mI.EngineOn == false)
        {
            speed -= 0.002f;
            Wings.transform.Rotate(0, speed, 0);
            if (speed <= 0)
                speed = 0;
        }
    }
}
