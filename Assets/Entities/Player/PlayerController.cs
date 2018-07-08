using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public float padding = 1f;
    public GameObject projectile;
    public float projectileSpeed;
    public float fireRate = 0.2f;
    public float health = 300f;
    public AudioClip shotSound;
    public float shotVolume = 1f;

    float xMin;
    float xMax;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0f)
            {
                Die();
            }
            Debug.Log("Player hit!");
        }
    }

    void Die()
    {
        FindObjectOfType<SceneLoader>().LoadScene("Win Screen");
        Destroy(gameObject);
    }

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
    }

    void Fire()
    {
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, projectileSpeed, 0f);
        AudioSource.PlayClipAtPoint(shotSound, transform.position, shotVolume);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
       
        //restrict player to gamespace
        float xNew = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xNew, transform.position.y, transform.position.z);
	}
}