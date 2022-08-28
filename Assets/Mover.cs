using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{   
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float thrustForce = 1000.0f;
    [SerializeField] float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        processThrust();
        processRotation();
    }
    void processThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*Time.deltaTime*thrustForce);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        }
        else
        {
            audioSource.Stop();
        }
       
        
    }

    void processRotation(){
         if (Input.GetKey(KeyCode.A))
        {
            applyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            applyRotation(-rotationSpeed);
        }
    }

    void applyRotation(float rotat)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward, Time.deltaTime * rotat);
        rb.freezeRotation = false;
    }
}


