using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public float health = 150f;   
    public float projectileSpeed = 5f;


    void Update()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject enemyBeam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
            enemyBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        }
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
