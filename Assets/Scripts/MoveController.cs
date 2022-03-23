using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5;

    private float SpeedInput, TurnInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Vertical")* transform.forward * speed * Time.deltaTime);
    }

}
