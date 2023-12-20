using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float fastSpeed = 15f;
    [SerializeField] float slowSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmout = Input.GetAxis("Horizontal") * steerSpeed*Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed*Time.deltaTime;

        transform.Rotate(0, 0, -steerAmout);
        transform.Translate(0,moveAmount,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Boost")
        {
            moveSpeed = fastSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}
