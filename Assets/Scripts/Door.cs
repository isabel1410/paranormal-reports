using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    public GameObject text;
    [SerializeField]
    public Animator animator;

    private bool inRange;

    public void Start()
    {
        text.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            inRange = true;
            Debug.Log("in range!");
        }
    }

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
            Debug.Log("joe");
            animator.SetBool("Opened", true);
        }
    }
}
