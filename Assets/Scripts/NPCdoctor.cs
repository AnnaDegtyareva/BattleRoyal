using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCdoctor : MonoBehaviour
{
    List<string> greetsD = new List<string>();
    List<GameObject> npc = new List<GameObject>();
    [SerializeField] GameObject player;

    void Start()
    {
        greetsD.Add("Привет!");
        greetsD.Add("Тут человеку плохо, а ты...");
        greetsD.Add("Ты болен?");
        greetsD.Add("Вы его знали?");
        greetsD.Add("Лечу не бесплатно");
        greetsD.Add("Вам чем-то помочь?");
        greetsD.Add("С вами всё в порядке?");

    }

    private void OnTriggerEnter(Collider other)
    {
        //Случайный индекс от 0 до максимального индекса
        int index = Random.Range(0, greetsD.Count);
        print(greetsD[index]);

    }
 
}
