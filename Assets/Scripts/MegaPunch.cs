using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MegaPunch : MonoBehaviour
{
    [SerializeField] private float punchPower;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.rigidbody != null) 
                {
                    _audioSource.Play(0);
                    StartCoroutine(ExampleCoroutine());  
                }
            } 
        }
    }

    void Punch() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hit.rigidbody.AddForce(ray.direction * punchPower, ForceMode.Acceleration);
        } 
    }

     IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.8f);

        //After we have waited 5 seconds print the time again.
        Punch();
    }
}
