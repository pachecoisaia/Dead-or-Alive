using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Rigidbody rb;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");
	
	    Vector3 Movement = new Vector3(xMov, 0f, zMov) * moveSpeed * Time.deltaTime;
	    transform.Translate(Movement, Space.Self);

        //rb.velocity = new Vector3(xMov, rb.velocity.y, 		//zMov) * moveSpeed;
    }

}
