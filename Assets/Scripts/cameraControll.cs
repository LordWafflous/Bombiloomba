using UnityEngine;
using Cinemachine;

public class cameraControll : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("player");
        if (player != null)
        {
            virtualCam.Follow = player.transform;
        }
    }
}
