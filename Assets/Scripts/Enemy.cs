using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;//������ - �����
    [SerializeField] float shootRadius = 15; //������ ��������
    [SerializeField] GameObject rifleStart;//����� ������ ����
    [SerializeField] GameObject bullet;//����
    float timer = 0;//������
    float cooldown = 2;//���� ��� �������
    [SerializeField] float findRadius = 30;//������ � �������� ���� ��� �������� � �������� ������������
    [SerializeField] float speed = 10;//�������� �����
    [SerializeField] Animator animator;//��������
    bool isDead = false;//�������� ���������� ��� �������� ������

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject; //������� ������
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < shootRadius && isDead == false)//���� ���� � ������� ��������, ��
        {
            transform.LookAt(player.transform);
            //����� ���� ������������� ������� � ���
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                //��������
                GameObject buffer = Instantiate(bullet);
                buffer.GetComponent<Bullet>().SetDirection(transform.forward);
                buffer.transform.position = rifleStart.transform.position;
                buffer.transform.rotation = rifleStart.transform.rotation;
            }
            animator.SetBool("IsRun", false);//������

        }
        else if (Vector3.Distance(transform.position, player.transform.position) < findRadius && isDead == false)//����� ���� ���� � ������� ������, ��
        {
            //���� � ����
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * speed);
            animator.SetBool("IsRun", true);//������
        }
        else
        {
            animator.SetBool("IsRun", false);//������
        }

        
    }
    public void Dead()//������� ��� ������
    {
        animator.SetTrigger("Dead");//����������� �������� ������
        GetComponent<CharacterController>().enabled = false;//�������� ��������� �� �������
        isDead = true;//�������� ���������� ������ ������ ���������
    }
}

