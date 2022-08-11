using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 30f;
    [SerializeField] private float speed = 20;
    private Vector3 direction;

    private void Start()
    {
        direction = -transform.forward;
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        transform.position -= direction * speed * Time.deltaTime;
    }
}
