using UnityEngine;
namespace UseCases
{
    public class CookiesItems : MonoBehaviour
    {

        string ID;
        public void SetID ( string _newID)
        {
            ID = _newID;
        }

        private void OnTriggerEnter(Collider other)
        {
            Services.Instance.GetService<ICookiesSpawner>().OnGrabCookies(ID);
            Delegates.Register_OnEarnPoints?.Invoke(1f);
            Destroy(gameObject);
        }
    }
}



