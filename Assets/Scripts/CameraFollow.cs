using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public GameObject prefabSpawned;
    public CinemachineVirtualCamera cinemachineCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedInstance = Instantiate(prefabSpawned, new Vector3(0, 0, 0), Quaternion.identity);
        cinemachineCamera.Follow = spawnedInstance.transform;
        cinemachineCamera.LookAt = spawnedInstance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
