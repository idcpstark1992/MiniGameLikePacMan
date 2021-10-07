using UnityEngine;
using System.Collections;
namespace ExternalLayer
{
    public  class TweeningClass : MonoBehaviour , ITween
    {

        [SerializeField] private float WFSAmount;
        private WaitForSeconds waitForSeconds;
        private void Start()
        {
            waitForSeconds = new WaitForSeconds(WFSAmount);
        }

        public static bool IsTweening = false;
        /// <summary>
        /// Rotate Player Rigid body
        /// </summary>
        /// <param name="_anglesDegrees"> Movement on Y axis</param>
        /// <param name="_ObjecToTween"> rigid body that you neer rotate </param>
        /// <param name="_movementSmothTime">   </param>
        public  void DoTween(float _anglesDegrees, Rigidbody _ObjecToTween, float _movementSmothTime)
        {
            StartCoroutine(C_DoTween(_anglesDegrees, _ObjecToTween, _movementSmothTime));
        }
        
        private IEnumerator C_DoTween(float _angle, Rigidbody _TweenTo, float _SmoothTime)
        {

            Vector3 CurrentRbQuaternion = _TweenTo.rotation.eulerAngles;
            Vector3 TargetRbQuaternion = new Vector3(CurrentRbQuaternion.x, CurrentRbQuaternion.y + _angle, CurrentRbQuaternion.z);
            Quaternion mTargetQuaternion = Quaternion.Euler(TargetRbQuaternion);
            float mTweenDistance = 0;
            do
            {
                IsTweening = true;
                _TweenTo.rotation = Quaternion.Lerp(_TweenTo.rotation, mTargetQuaternion, Time.deltaTime * _SmoothTime);
                mTweenDistance = Mathf.Abs(_TweenTo.rotation.eulerAngles.y - mTargetQuaternion.eulerAngles.y);
                yield return waitForSeconds;

            } while (mTweenDistance>.2f);
            IsTweening = false;
        }
         

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Time"></param>
        /// <param name="_Transform"></param>
        /// <param name="_movementType">0 = In Movement , 1 = Out Movement  , 2= in Out Movement</param>
        public void DoUITween(float _Time, RectTransform _Transform, int _movementType)
        {
            throw new System.NotImplementedException();
        }
        
    }
}

