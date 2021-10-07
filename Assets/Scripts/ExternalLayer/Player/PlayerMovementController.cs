using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExternalLayer
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementController : MonoBehaviour
    {

        [SerializeField] private Rigidbody PlayerRigidBody;
        [SerializeField] private float RotationAmount;
        [SerializeField] private float RotationTimeAmount;
        [SerializeField] private float MovementAmountSoftness;
        [SerializeField] private PlayerVoidChecker VoidCheckerOnPlayer;

       
        void Start()
        {
            PlayerRigidBody     = GetComponent<Rigidbody>();
            VoidCheckerOnPlayer = GetComponent<PlayerVoidChecker>();
            Delegates.Register_OnResetScene += OnResetScene;
        }
        private void OnDisable()
        {
            Delegates.Register_OnResetScene -= OnResetScene;
        }

        // Update is called once per frame
        void Update()
        {
            float InputVertical = Input.GetAxis("Vertical");
            float InputHorizontal = Input.GetAxis("Horizontal");
            if ((InputHorizontal > .3f || InputHorizontal < -.3f) && !TweeningClass.IsTweening)
            {
                Services.Instance.GetService<ITween>().DoTween(InputHorizontal > 0 ? RotationAmount : RotationAmount * -1, PlayerRigidBody, RotationTimeAmount);
            }
            if (InputVertical != 0 && !TweeningClass.IsTweening)
            {
                PlayerRigidBody.MovePosition(PlayerRigidBody.position + transform.forward * InputVertical * MovementAmountSoftness);
            }
        }

        private void OnResetScene()
        {
            gameObject.transform.position = Vector3.up;
        }
    }
}

