using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float lifeTime = 20f;
    //effects
    [SerializeField] GameObject particle; // добавляем ссылку на эффект дыма


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        Instantiate(particle, transform.position, particle.transform.rotation);//создаём дым в месте огня

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
