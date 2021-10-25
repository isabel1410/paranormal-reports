using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] Cameras;

    int currentCam;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = 0;
        SetCam(currentCam);
    }

    public void SetCam(int idx)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == idx)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    public void NextCam()
    {
        currentCam++;
        if (currentCam > Cameras.Length - 1)
            currentCam = 0;
        SetCam(currentCam);
    }

    public void LastCam()
    {
        currentCam--;
        if (currentCam < 0)
            currentCam = Cameras.Length - 1;
        SetCam(currentCam);
    }
}

