using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float lifeTime = 20f;
    //effects
    [SerializeField] GameObject particle; // ��������� ������ �� ������ ����


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        Instantiate(particle, transform.position, particle.transform.rotation);//������ ��� � ����� ����

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
