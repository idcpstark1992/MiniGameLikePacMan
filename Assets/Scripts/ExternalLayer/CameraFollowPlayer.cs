using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 CameraOffset;
    [SerializeField] private Transform PlayerTarget;
    [SerializeField, Range(0, 5)]
    float SmoothFactor;
    private void OnEnable()
    {
        Delegates.Register_OnResetScene += OnResetGame;
    }
    private void OnDisable()
    {
        Delegates.Register_OnResetScene -= OnResetGame;
    }
    private void OnResetGame()
    {
        transform.position = PlayerTarget.position;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerTarget.position, Time.deltaTime * SmoothFactor);
    }
}
