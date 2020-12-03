
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
   [SerializeField] float health=200f;
   [SerializeField] float ShootCountDown;
   [SerializeField] float minShootCD=0.3f;
   [SerializeField] float maxShootCD=2f;
   [SerializeField] GameObject Enemylaser;
   [SerializeField] float laserspeed = 10f;
    [SerializeField] GameObject DestroyEfect;
    [SerializeField] float durationofExplosion = 1f;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.5f;

    [Header("Lazer")]

    [SerializeField] [Range(0, 1)] float LazerSoundVolume = 0.5f;
    [SerializeField] AudioClip LazerSound;

    void Start()
    {
        ShootCountDown = Random.Range(minShootCD, maxShootCD);
    }

    
    void Update()
    {
        CountDownandShoot();
    }

    private void CountDownandShoot()
    {
        ShootCountDown -= Time.deltaTime;
        if (ShootCountDown <= 0f)
        {
            Fire();
            ShootCountDown = Random.Range(minShootCD, maxShootCD);
        }
    }

    private void Fire()
    {
     
        GameObject laser = Instantiate(Enemylaser, transform.position + (transform.forward * 0.5f), Quaternion.identity) as GameObject;
        /*transform.position + (transform.forward * 2)*/
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-laserspeed);
        AudioSource.PlayClipAtPoint(LazerSound, Camera.main.transform.position, LazerSoundVolume);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damagedealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damagedealer) { return; }
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
}
