using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private GameObject text;

    //[SerializeField]
    //private List<AudioClip> openDoorSounds;
    //private AudioClip randomOpenDoorSound;

    //[SerializeField]
    //private List<AudioClip> closeDoorSounds;
    //private AudioClip randomCloseDoorSound;

    //private AudioSource source;
    private Animator animator;

    private bool inRange;



    public void Start()
    {
        animator = GetComponentInParent<Animator>();
        text.SetActive(false);

        //source = GetComponent<AudioSource>();

        //Audio.OnOpenDoor += OnOpenDoor;
        //Audio.OnCloseDoor += OnCloseDoor;
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
        // Only open door when within range
        if (inRange)
        {
            StartCoroutine("UseDoor");
        }
    }

    // Handles waiting seconds to close door again.
    IEnumerator UseDoor()
    {
        animator.SetBool("Opened", true);

        yield return new WaitForSeconds(5f);

        animator.SetBool("Opened", false);
    }

    //public void OnOpenDoor()
    //{
    //    randomOpenDoorSound = openDoorSounds[Random.Range(0, openDoorSounds.Count)];
    //    source.clip = randomOpenDoorSound;
    //    source.Play();
    //    Debug.Log("Open door sound played");
    //}

    //public void OnCloseDoor()
    //{
    //    randomCloseDoorSound = closeDoorSounds[Random.Range(0, closeDoorSounds.Count)];
    //    source.clip = randomCloseDoorSound;
    //    source.Play();
    //    Debug.Log("Close door sound played");
    //}

}
