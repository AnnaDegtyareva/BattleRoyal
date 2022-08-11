using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Text HPText;
    [SerializeField] public int health;
    [SerializeField] GameObject rifleStart;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject GameOver;
    [SerializeField] Animator cameraAnimator;
    [SerializeField] Animator recoilAnimator;
    [SerializeField] AudioSource perezaryadkaAudio;
    [SerializeField] int QuantityBullets;
    [SerializeField] Text BulletsText;
    [SerializeField] bool Shoot = true;
    [SerializeField] Text MoneyText;
    [SerializeField] public int money;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject Secret;
    [SerializeField] GameObject Farah;
    [SerializeField] GameObject Sema;
    [SerializeField] GameObject Aloe;
    [SerializeField] GameObject Script;
    [SerializeField] GameObject SubZero;
    [SerializeField] GameObject MC;
    [SerializeField] GameObject Impulsee;



    // Start is called before the first frame update
    void Start()
    {
        ChangeHealth(100);
        ChangeBullets(10);
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = health.ToString();//кол-во хп выводим на экран
        BulletsText.text = QuantityBullets.ToString();//кол-во пуль выводим на экран
        MoneyText.text = money.ToString();//кол-во собранных денег выводим на экран
        if ((Input.GetKeyDown(KeyCode.Mouse0)) && Shoot == true) //нажали лкм
        {
            GameObject buffer = Instantiate(bullet);
            buffer.GetComponent<Bullet>().SetDirection(transform.forward);
            buffer.transform.position = rifleStart.transform.position;
            buffer.transform.rotation = rifleStart.transform.rotation;
            //отдача
            recoilAnimator.SetTrigger("isRecoil");
            ChangeBullets(-1);
        }
        //прицел вкл если нажата пкм
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            cameraAnimator.SetBool("isAim", true);
        }
        //прицел выкл если пкм отпущена 
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            cameraAnimator.SetBool("isAim", false);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(Shoot == false)
            {
                perezaryadkaAudio.Play();//перез€р€дка
                recoilAnimator.SetTrigger("isRecharge");
                ChangeBullets(10);
                Shoot = true;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Secret.SetActive(false);
            Farah.SetActive(false);
            Sema.SetActive(false);
            Aloe.SetActive(false);
            Script.SetActive(false);
            SubZero.SetActive(false);
            MC.SetActive(false);
            Impulsee.SetActive(false);
        }
    }

    public void ChangeMoney(int count)
    {
        money = money + count;
        if(money >= 5000000)//провер€ем, достигли ли мы 5л€мов
        {
            WinScreen.SetActive(true);//вкл экран победы
            //вкл курсор
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ChangeHealth(int count)
    {
        health = health +  count;
        if (health <= 0)//делаем проверку проигрыша
        {
            GameOver.SetActive(true);//вкл экран проигрыша
            //вкл курсор
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            GetComponent<PlayerMove>().Dead();
        }
    }
    public void ChangeBullets(int count)
    {
        QuantityBullets = QuantityBullets + count;
        if (QuantityBullets <= 0)
        {
            Shoot = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire")
        {
            health -= 1;
        }
        if (other.tag == "HP" && health <= 70)
        {
            ChangeHealth(30);
            Destroy(other.gameObject);
        }
        if (other.tag == "HP" && health > 70)
        {
            ChangeHealth(100-health);
            Destroy(other.gameObject);
        }
        if(other.tag == "Secret")
        {
            ChangeMoney(10000);
            Secret.SetActive(true);
            Destroy(other.gameObject);
        }
        if(other.tag == "Farah")
        {
            ChangeMoney(750000);
            Farah.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag == "Sema")
        {
            ChangeHealth(100000);
            Sema.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag == "Script")
        {
            ChangeMoney(50000);
            Script.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag == "Aloe41")
        {
            ChangeMoney(500000);
            Aloe.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag == "SubZero")
        {
            ChangeMoney(9684);
            SubZero.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag == "MC")
        {
            ChangeMoney(300000);
            MC.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag == "Impulsee")
        {
            ChangeMoney(300000);
            Impulsee.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
