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
        var ht = ("эй.. эй.. ты живой? блин... похоже ты ничего не помнишь... Тебя зовут " ,Name, ", ты уже ", Ear, " лет живёшь тем, что грабишь банки, используя только ",Gun, ". Конечно тебя объявили в розыск, за тебя обещают 1 000 000 000$ Ты рисковый, недавно занял деньжищ у ",EnemyName, ", лямов 5. А теперь должен вернуть, поэтому пошёл грабить ",Bank,",но кто-то тебя опередил и взорвал банк пока ты был там... С тебя шкуру снимут если деньги не вернёшь. Но к счастью, у тебя есть припрятанные деньги, они в бочках. Тебе надо взорвать все бочки, что бы собрать деньги и вернуть долг. Но это будет нелегко, весь, ну или почти весь, город хочет тебя убить. На всякий случай, по городу валяются аптечки и пушки. Но у тебя ограничено время, если ты не успеешь всё собрать до того, как зона съест тебя, ты погиб... А теперь иди и ищи деньги, удачи.");
        historyText.text = ht.ToString(); 
    }


    // Update is called once per frame
    void Update()
    {
        History();
    }
}
