using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] float waitCooldown;//время до запуска зоны
    [SerializeField] float moveCooldown;//время ходьбы зоны
    float waitTime;
    float moveTime;
    [SerializeField] float sizeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;//время до запуска зоны

        if (waitTime > waitCooldown)
        {
            moveTime += Time.deltaTime;

            transform.localScale -= new Vector3(sizeSpeed, 0, sizeSpeed);//сужение зоны

            if (moveTime > moveCooldown)
            {
                waitTime = 0;
                moveTime = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)//тут будем убивать врагов и отнимат хп у игрока, если они зашли за зону
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().ChangeHealth(-1000);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Dead();
        }
    }
}
