using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour
{
    Rigidbody _rbBody;
    AudioSource _audioSource;
    public bool EngineOn {get; private set;}
    public float moveSpeed = 8f;
    float HeliX;
    float HeliY;
    void Start()
    {
        _rbBody = GetComponent<Rigidbody>();
        EngineOn = false;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HeliX = Input.GetAxis("Horizontal");
        HeliY = Input.GetAxis("Vertical");

        _rbBody.AddForce(HeliX, 0, HeliY);

        if (Input.GetKeyDown(KeyCode.R))
        {
            EngineOn = !EngineOn;
            if (EngineOn)
                _audioSource.Play();
        }
        if (EngineOn)
        {
           _audioSource.volume = 1.0f;
        }
        else
        {
            _audioSource.volume -= Time.deltaTime / 2;
            if (_audioSource.volume <= 0.0f)
                _audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.E) && EngineOn == true)
        {
            _rbBody.AddForce(0, 1, 0);
        }
        if(Input.GetKeyUp(KeyCode.E) && EngineOn == true)
        {
            _rbBody.useGravity = false;
            _rbBody.velocity = Vector3.zero;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            _rbBody.AddForce(0, -1, 0);
        }
        if (EngineOn == false)
        {
            _rbBody.useGravity = true;
        }
    }

}
