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
        greetsD.Add("������!");
        greetsD.Add("��� �������� �����, � ��...");
        greetsD.Add("�� �����?");
        greetsD.Add("�� ��� �����?");
        greetsD.Add("���� �� ���������");
        greetsD.Add("��� ���-�� ������?");
        greetsD.Add("� ���� �� � �������?");

    }

    private void OnTriggerEnter(Collider other)
    {
        //��������� ������ �� 0 �� ������������� �������
        int index = Random.Range(0, greetsD.Count);
        print(greetsD[index]);

    }
 
}
