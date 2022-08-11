using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;
    bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "Player")
        {
            if (isOpen == false)
            {
                doorAnimator.SetTrigger("Open");
                isOpen = true;
            }
            else
            {
                doorAnimator.SetTrigger("Close");
                isOpen = false;
            }
        }
    }
}
