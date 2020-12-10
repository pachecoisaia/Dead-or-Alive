using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.5f)]
    private float fireRate = .5f;
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;
    //private ParticleSystem ps;

    public GameObject mp5, ak47, m4;
    private int indexOfSelectedGun = 0;
    private float timer;

    public AudioSource[] gunSounds;

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

            if (Input.GetKey(KeyCode.Alpha1)) {
                mp5.SetActive(true);
                ak47.SetActive(false);
                m4.SetActive(false);
                indexOfSelectedGun = 0;
                fireRate = .5f;
                damage = 4;
                

            }
            if (Input.GetKey(KeyCode.Alpha2)) {
                mp5.SetActive(false);
                ak47.SetActive(true);
                m4.SetActive(false);
                indexOfSelectedGun = 1;
                fireRate = .33f;
                damage = 5;
            }
            if (Input.GetKey(KeyCode.Alpha3)) {
                mp5.SetActive(false);
                ak47.SetActive(false);
                m4.SetActive(true);
                indexOfSelectedGun = 2;
                fireRate = .1f;
                damage = 10;
            }
        }
    }
    void FireGun()
    {
        PlayGunSound();
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
    
    void PlayGunSound() {
        gunSounds[indexOfSelectedGun].Play();
    }
}