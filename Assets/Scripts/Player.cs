using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [Header("Player")]

    [SerializeField]float movementspeed=10f;
    [SerializeField] float health = 1000f;
    [SerializeField] GameObject DestroyEfect;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.5f;
    [SerializeField] AudioClip DeathSound;

    [Header("Projectile")]
    [SerializeField] GameObject Shootinglaser;
    [SerializeField] float firingSpeed = 15f;
    [SerializeField] float firingperiod = 0.1f;
    [SerializeField] float durationofExplosion = 1f;

    [Header("SoundEffect")]
    [SerializeField] [Range(0, 1)] float LazerSoundVolume = 0.5f;
    [SerializeField] AudioClip LazerSound;



    Coroutine FireCoroutine;
    float xmin;
    float xmax;
    float ymin;
    float ymax;

    void Start()
    {
        Boundraries();
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damagedealer = other.gameObject.GetComponent<DamageDealer>();
        damagedealer.Hit();
        KillTheEnemy(damagedealer);

    }

    private void KillTheEnemy(DamageDealer damagedealer)
    {
        health -= damagedealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(DestroyEfect, transform.position, Quaternion.identity);
            Destroy(explosion, durationofExplosion);
            AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, deathSoundVolume);


        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireCoroutine = StartCoroutine(FiringCoroutine());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(FireCoroutine);
        }
    }

    IEnumerator FiringCoroutine()
    {
        while (true)
        {
            GameObject laser = Instantiate(Shootinglaser, transform.position+(transform.forward*0.5f), Quaternion.identity) as GameObject;
           /*Instantiate(meleePrefab, transform.position + (transform.forward * 2), transform.rotation);*/
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, firingSpeed);
            AudioSource.PlayClipAtPoint(LazerSound, Camera.main.transform.position, LazerSoundVolume);
            yield return new WaitForSeconds(firingperiod);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * movementspeed * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * movementspeed * Time.deltaTime;
        var newPosX = Mathf.Clamp(transform.position.x + deltaX, xmin, xmax);
        var newPosY = Mathf.Clamp(transform.position.y + deltaY, ymin, ymax);
        transform.position = new Vector2(newPosX, newPosY);
    }

    private void Boundraries()
    {
        Camera camera = Camera.main;
        xmin = camera.ViewportToWorldPoint(new Vector3(0.04f, 0, 0)).x;
        xmax = camera.ViewportToWorldPoint(new Vector3(0.96f, 0, 0)).x;
        ymin = camera.ViewportToWorldPoint(new Vector3(0, 0.06f, 0)).y;
        ymax = camera.ViewportToWorldPoint(new Vector3(0, 0.94f, 0)).y;
    }

}
