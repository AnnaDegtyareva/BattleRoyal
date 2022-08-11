using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;//мишень - игрок
    [SerializeField] float shootRadius = 15; //радиус стрельбы
    [SerializeField] GameObject rifleStart;//место спавна пули
    [SerializeField] GameObject bullet;//пуля
    float timer = 0;//таймер
    float cooldown = 2;//надо для таймера
    [SerializeField] float findRadius = 30;//радиус с которого враг нас замечает и начинает приследовать
    [SerializeField] float speed = 10;//скорость врага
    [SerializeField] Animator animator;//аниматор
    bool isDead = false;//буллевая переменная для проверки смерти

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject; //Находим игрока
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < shootRadius && isDead == false)//если цель в радиусе стрельбы, то
        {
            transform.LookAt(player.transform);
            //чтобы враг автоматически стрелял в нас
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                //Стрелять
                GameObject buffer = Instantiate(bullet);
                buffer.GetComponent<Bullet>().SetDirection(transform.forward);
                buffer.transform.position = rifleStart.transform.position;
                buffer.transform.rotation = rifleStart.transform.rotation;
            }
            animator.SetBool("IsRun", false);//стойка

        }
        else if (Vector3.Distance(transform.position, player.transform.position) < findRadius && isDead == false)//иначе если цель в радиусе ходьбы, то
        {
            //идти к цели
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * speed);
            animator.SetBool("IsRun", true);//ходьба
        }
        else
        {
            animator.SetBool("IsRun", false);//стойка
        }

        
    }
    public void Dead()//функция для смерти
    {
        animator.SetTrigger("Dead");//проигрываем анимацию смерти
        GetComponent<CharacterController>().enabled = false;//перестаём охотиться за игроком
        isDead = true;//буллевую переменную Смерть делаем Правдивой
    }
}

