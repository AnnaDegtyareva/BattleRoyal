using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public InputField inputFieldName;
    [SerializeField] public string Name;
    [SerializeField] public InputField inputFieldGun;
    [SerializeField] public string Gun;
    [SerializeField] public InputField inputFieldEar;
    [SerializeField] public string Ear;
    [SerializeField] public InputField inputFieldEnemyName;
    [SerializeField] public string EnemyName;
    [SerializeField] public InputField inputFieldBank;
    [SerializeField] public string Bank;
    [SerializeField] public Text historyText;
    // Start is called before the first frame update
    public void SaveInputText()
    {
        Name = inputFieldName.text;
        Gun = inputFieldGun.text;
        Ear = inputFieldEar.text;
        EnemyName = inputFieldEnemyName.text;
        Bank = inputFieldBank.text;
    }

    public void History()
    {
        var ht = ("��.. ��.. �� �����? ����... ������ �� ������ �� �������... ���� ����� " ,Name, ", �� ��� ", Ear, " ��� ����� ���, ��� ������� �����, ��������� ������ ",Gun, ". ������� ���� �������� � ������, �� ���� ������� 1 000 000 000$ �� ��������, ������� ����� ������� � ",EnemyName, ", ����� 5. � ������ ������ �������, ������� ����� ������� ",Bank,",�� ���-�� ���� �������� � ������� ���� ���� �� ��� ���... � ���� ����� ������ ���� ������ �� ������. �� � �������, � ���� ���� ������������ ������, ��� � ������. ���� ���� �������� ��� �����, ��� �� ������� ������ � ������� ����. �� ��� ����� �������, ����, �� ��� ����� ����, ����� ����� ���� �����. �� ������ ������, �� ������ �������� ������� � �����. �� � ���� ���������� �����, ���� �� �� ������� �� ������� �� ����, ��� ���� ����� ����, �� �����... � ������ ��� � ��� ������, �����.");
        historyText.text = ht.ToString(); 
    }


    // Update is called once per frame
    void Update()
    {
        History();
    }
}
