using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    private Animator animator;

    private bool inRange;

    public void Start()
    {
        animator = GetComponentInParent<Animator>();
        text.SetActive(false);
    }

    // Check if player is in range
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            inRange = true;
            Debug.Log("in range!");
        }
    }

    // Check if player is out of range
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
            inRange = false;
            Debug.Log("out of range!");
        }
    }

    public void OpenDoor()
    {
        if (inRange)
        {
            StartCoroutine("UseDoor");
        }
    }

    IEnumerator UseDoor()
    {
        animator.SetBool("Opened", true);

        yield return new WaitForSeconds(5f);

        animator.SetBool("Opened", false);
    }
}
