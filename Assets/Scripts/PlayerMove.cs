using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;//контроллер игрока
    [SerializeField] float speed = 10;//скорость
    [SerializeField] float gravity = 50;//гравитация
    [SerializeField] float jumpForce = 30;//высота прыжка
    [SerializeField] Animator animator;//аниматор
    bool isDead = false;//смерть
    bool isRun = false;//бег
    [SerializeField] AudioSource stepsAudio;//аудио

    Vector3 direction;//вектор

    void Update()
    {
        // moveHorizontal будет принимать значение -1 если нажата кнопка A, 1 если нажата D, 0 если эти кнопки не нажаты
        float moveHorizontal = Input.GetAxis("Horizontal");
        // moveVertical будет принимать значение -1 если нажата кнопка S, 1 если нажата W, 0 если эти кнопки не нажаты
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q))//при нажатии на Q
        {
            GetComponent<PlayerLook>().enabled = false;//вкл курсор
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0); //переходим в меню
        }

        if (controller.isGrounded && isDead == false) //проверяем что мы не на земле (тема условий будет дальше)
        {
            //Редактируем переменную направления, используя moveHorizontal и moveVertical
            //Мы двигаемся по координатам x и z, координата y для прыжков.
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            if (direction.magnitude > 0 && isDead == false)//проверяем что длина вектора направления движения больше нуля
            {
                animator.SetBool("IsRun", true);//переключаем параметр анимации Бег в правду
                if (isRun == false)
                {
                    stepsAudio.Play();
                    isRun = true;
                }
               
            }
            else//иначе
            {
                animator.SetBool("IsRun", false);//переключаем параметр анимации Бег в ложь
                if (isRun == true)
                {
                    stepsAudio.Stop();
                    isRun = false;
                }
            }

            //Дополнительно умножая его на скорость передвижения (преобразуя локальные координаты к глобальным)
            direction = transform.TransformDirection(direction) * speed;

            if (Input.GetKey(KeyCode.Space) && isDead == false) //Проверяем что нажали пробел для прыжка
            {
                direction.y = jumpForce;//поднимаем игрока по У
                animator.SetTrigger("Jump");//включаем анимацию прыжка
            }
        }

        //Этой строчкой мы осуществляем изменение положения игрока на основе вектора direction
        //Time.deltaTime это количество секунд которое прошло с последнего кадра, для синхронизации по времени
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);

        //код для ускорения ходьбы/бега игрока
        if (Input.GetKeyDown(KeyCode.LeftShift) && isDead == false)//проверка нажатия левого шифта и того, что мы не мёртвы
        {
            speed = speed + 15;//увеличение скорости
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && isDead == false)//проверка того, что мы отпустили левый шифт
        {
            speed = speed - 15;//уменьшение скорости
        }
    }
    public void Dead()//функция для смерти
    {
        animator.SetTrigger("Dead");//проигрываем анимацию смерти        
        isDead = true;//буллевую переменную Смерть делаем Правдивой
    }
}

