using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;//���������� ������
    [SerializeField] float speed = 10;//��������
    [SerializeField] float gravity = 50;//����������
    [SerializeField] float jumpForce = 30;//������ ������
    [SerializeField] Animator animator;//��������
    bool isDead = false;//������
    bool isRun = false;//���
    [SerializeField] AudioSource stepsAudio;//�����

    Vector3 direction;//������

    void Update()
    {
        // moveHorizontal ����� ��������� �������� -1 ���� ������ ������ A, 1 ���� ������ D, 0 ���� ��� ������ �� ������
        float moveHorizontal = Input.GetAxis("Horizontal");
        // moveVertical ����� ��������� �������� -1 ���� ������ ������ S, 1 ���� ������ W, 0 ���� ��� ������ �� ������
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q))//��� ������� �� Q
        {
            GetComponent<PlayerLook>().enabled = false;//��� ������
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0); //��������� � ����
        }

        if (controller.isGrounded && isDead == false) //��������� ��� �� �� �� ����� (���� ������� ����� ������)
        {
            //����������� ���������� �����������, ��������� moveHorizontal � moveVertical
            //�� ��������� �� ����������� x � z, ���������� y ��� �������.
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            if (direction.magnitude > 0 && isDead == false)//��������� ��� ����� ������� ����������� �������� ������ ����
            {
                animator.SetBool("IsRun", true);//����������� �������� �������� ��� � ������
                if (isRun == false)
                {
                    stepsAudio.Play();
                    isRun = true;
                }
               
            }
            else//�����
            {
                animator.SetBool("IsRun", false);//����������� �������� �������� ��� � ����
                if (isRun == true)
                {
                    stepsAudio.Stop();
                    isRun = false;
                }
            }

            //������������� ������� ��� �� �������� ������������ (���������� ��������� ���������� � ����������)
            direction = transform.TransformDirection(direction) * speed;

            if (Input.GetKey(KeyCode.Space) && isDead == false) //��������� ��� ������ ������ ��� ������
            {
                direction.y = jumpForce;//��������� ������ �� �
                animator.SetTrigger("Jump");//�������� �������� ������
            }
        }

        //���� �������� �� ������������ ��������� ��������� ������ �� ������ ������� direction
        //Time.deltaTime ��� ���������� ������ ������� ������ � ���������� �����, ��� ������������� �� �������
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        //��� ��� ��������� ������/���� ������
        if (Input.GetKeyDown(KeyCode.LeftShift) && isDead == false)//�������� ������� ������ ����� � ����, ��� �� �� �����
        {
            speed = speed + 15;//���������� ��������
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && isDead == false)//�������� ����, ��� �� ��������� ����� ����
        {
            speed = speed - 15;//���������� ��������
        }
    }
    public void Dead()//������� ��� ������
    {
        animator.SetTrigger("Dead");//����������� �������� ������        
        isDead = true;//�������� ���������� ������ ������ ���������
    }
}

