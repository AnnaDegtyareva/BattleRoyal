using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10;
    private Vector3 direction;
    [SerializeField] GameObject fire;

    private void Start()
    {
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
        Instantiate(fire, transform.position, fire.transform.rotation);//создаём огнь
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Dead();
            //Destroy(other.gameObject);
        }
        if (other.tag == "Chicken")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().ChangeHealth(-5);
        }
        if (other.tag == "RedBarrel")
        {
            other.GetComponent<RedBarrel>().Boom();
        }
        if (other.tag != "Zone")
        {
            Destroy(gameObject);
        }
    }
}
