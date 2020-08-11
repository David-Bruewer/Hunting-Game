using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;

public class PlayerCameraController : MonoBehaviour
{
    public bool isFound = false; 
    public CinemachineVirtualCamera virtualCamera;

    public GameObject player; 

    // Start is called before the first frame update
    public void Update()
    {
        if (isFound)
        {
            virtualCamera.Follow = player.transform;          
        }
    }
}
