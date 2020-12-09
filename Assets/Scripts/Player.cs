using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        //player movement
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");
	
	    Vector3 Movement = new Vector3(xMov, 0f, zMov) * moveSpeed * Time.deltaTime;

	    transform.Translate(Movement, Space.Self);
    }

}
