using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] List<GameObject> inventoryGuns = new List<GameObject>();
    [SerializeField] GameObject hand;
    [SerializeField] GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {
       if(currentGun!= null)
        {
            inventoryGuns.Add(currentGun);
        }
    }
    private void Update()
    {
        //проверка нажатия клавиш для смены оружия
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }
    }

    //функция для переключения оружия
    private void SwitchWeapon(int index)
    {
        for (int i = 0; i < inventoryGuns.Count; i++)
        {
            //Выкл оружия
            inventoryGuns[i].SetActive(false);
        }
        inventoryGuns[index].SetActive(true);
        currentGun = inventoryGuns[index];
    }
    
    //функция для поднятия оружия
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gun" && inventoryGuns.Count < 5)
        {
            other.gameObject.transform.SetParent(hand.transform);
            other.gameObject.transform.localPosition = Vector3.zero;
            other.gameObject.transform.localRotation = Quaternion.identity;
            other.gameObject.GetComponent<Collider>().enabled = false;
            inventoryGuns.Add(other.gameObject);
            if (currentGun != null)
            {
                currentGun.SetActive(false);
            }
            currentGun = other.gameObject;
        }
    }
}
