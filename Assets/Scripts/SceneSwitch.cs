using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void CreateCharacter()
    {
        SceneManager.LoadScene(2);
    }
    public void AboutTheGame()
    {
        SceneManager.LoadScene(3);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    [SerializeField] GameObject Character;
    [SerializeField] GameObject History;

    public void Next()
    {
        Character.SetActive(false);
        History.SetActive(true);
    }
    public void Results()
    {
        SceneManager.LoadScene(5);
    }
    public void Ricroll()
    {
        System.Diagnostics.Process.Start("https://youtu.be/dQw4w9WgXcQ");
    }
    public void Final()
    {
        SceneManager.LoadScene(4);
    }

}
