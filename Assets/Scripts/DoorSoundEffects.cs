using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundEffects : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> openDoorSounds;
    private AudioClip randomOpenDoorSound;

    [SerializeField]
    private List<AudioClip> closeDoorSounds;
    private AudioClip randomCloseDoorSound;

    private AudioSource source;

    private void Start()
    {
        source = GetComponentInChildren<AudioSource>();
    }

    private void OnOpenDoor()
    {
        randomOpenDoorSound = openDoorSounds[Random.Range(0, openDoorSounds.Count)];
        source.clip = randomOpenDoorSound;
        source.Play();
        Debug.Log("Open door sound played");
    }

    private void OnCloseDoor()
    {
        randomCloseDoorSound = closeDoorSounds[Random.Range(0, closeDoorSounds.Count)];
        source.clip = randomCloseDoorSound;
        source.Play();
        Debug.Log("Close door sound played");
    }
}
