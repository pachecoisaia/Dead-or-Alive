using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.5f)]
    private float fireRate = 1f;
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;
    //private ParticleSystem ps;


    private float timer;

    void Start()
    {
        //ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                //ps.Play();
                timer = 0f;
                FireGun();
            }
        }
    }
    void FireGun()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10000f, Color.red);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if(health != null)
            {
                Debug.Log("Hit " + hitInfo.collider);
                health.TakeDamage(damage);
            }
        }
    }
}


