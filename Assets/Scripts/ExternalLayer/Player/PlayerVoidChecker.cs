using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ExternalLayer.PlayerMovementController))]
public class PlayerVoidChecker : MonoBehaviour
{
    [SerializeField] private float PlayerMaxFall;
    private bool TriggeredEvent;
    public bool IsGrounded { get; private set; }
    private void Start()
    {
        TriggeredEvent = false;
        Delegates.Register_OnEndgame += OnEndgame;
        Delegates.Register_OnResetScene += OnResetGame;
    }
    private void OnDisable()
    {
        Delegates.Register_OnEndgame -= OnEndgame;
        Delegates.Register_OnResetScene -= OnResetGame;
    }
    private void OnResetGame()
    {
        TriggeredEvent = false;
    }
    private void OnEndgame()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }
    private void Update()
    {
       
        Ray mRay = new Ray(gameObject.transform.position, Vector3.down*40);
        IsGrounded = Physics.Raycast(mRay, out RaycastHit raycastHit, 100);

        if (gameObject.transform.position.y < PlayerMaxFall && !TriggeredEvent)
        {
            Delegates.Register_OnEndgame?.Invoke();
            TriggeredEvent = true;
        }
            
    }
}
