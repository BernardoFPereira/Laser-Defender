using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 5f;
    public float health = 150f;
    public float shotsPerSeconds = 0.5f;


    void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        GameObject enemyBeam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        enemyBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if(missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
