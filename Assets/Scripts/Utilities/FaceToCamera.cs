using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraFace;
    [SerializeField] private Transform PlayerFollow;
    [SerializeField] private Vector3 Offset;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cameraFace);
        transform.position = PlayerFollow.transform.position;
        transform.rotation = Quaternion.LookRotation(cameraFace.forward);
    }
}
