using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarrel : MonoBehaviour
{
    [SerializeField] private float radius = 10;
    [SerializeField] GameObject fire;
    public void Boom()
    {
        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        player.GetComponent<PlayerController>().ChangeMoney(500000);
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            player.GetComponent<PlayerController>().ChangeHealth(-10);
        }
        Destroy(gameObject);
        GameObject buffer = Instantiate(fire);
        buffer.transform.position = transform.position;

        var enemies = FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < radius)
            {
                enemies[i].Dead();
            }
        }



    }

}
