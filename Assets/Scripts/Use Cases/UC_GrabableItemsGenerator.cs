using UnityEngine;
using System.Linq;
using System.Collections.Generic;
namespace UseCases
{
    public class UC_GrabableItemsGenerator : MonoBehaviour, ICookiesSpawner
    {
        [SerializeField] private Material   CookiesMaterial;
        [SerializeField] private int        CoockiesAmount;
        private GameObject CookiesHolder;

        public static Dictionary<string, IBoardItemType> CookiesTypes = new Dictionary<string, IBoardItemType>();

        private void Awake()
        {
            CookiesHolder = new GameObject("cookies Holder Parent");
        }
        private void Start()
        {
            Delegates.Register_OnResetBoardItems += OnResetboard;
        }
        private void OnDisable()
        {
            Delegates.Register_OnResetBoardItems -= OnResetboard;
        }

        private void OnResetboard()
        {
            for (int i = 0; i < CookiesHolder.transform.childCount; i++)
            {
                Destroy(CookiesHolder.transform.GetChild(i).gameObject);
            }
        }

        public void SelectNewRandomPointToSpawnCookies()
        {
            throw new System.NotImplementedException();
        }

        public void OnGrabCookies(string _CookieInstanceID = null)
        {

            if(CookiesTypes.TryGetValue(_CookieInstanceID, out  IBoardItemType boardItem))
            {
                boardItem.SetItemTag(1);
            }
            CookiesTypes.Remove(_CookieInstanceID);
            var mReturn =  UC_BoardGenerator.BoardItemsList.Where(p => p.Value.GetItemBoardType() == 1);
            var mRandomPointSpawn = mReturn.ElementAt(Random.Range(0, mReturn.Count())).Value;
            mRandomPointSpawn.SetItemTag(2);
            mRandomPointSpawn.SetPointExternal();

        }

        public void RegisterNewType(string _IDCookie , IBoardItemType _InnerType)
        {
            if (!CookiesTypes.ContainsKey(_IDCookie))
            {
                CookiesTypes.Add(_IDCookie, _InnerType);
            }
        }

        public void GrabableItem(Vector3 _InnerPosition, IBoardItemType _BoardParent)
        {
            GameObject ToInstantiateCookie = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            if (ToInstantiateCookie.TryGetComponent(out Renderer _rend))
            {
                _rend.material = CookiesMaterial;
            }

            if (ToInstantiateCookie.TryGetComponent(out Collider _collider))
            {
                _collider.isTrigger = true;
            }
            ToInstantiateCookie.transform.rotation = Quaternion.Euler(Vector3.left * 90);
            ToInstantiateCookie.transform.localScale = new Vector3(1, .2f, 1);
            ToInstantiateCookie.AddComponent<CookiesItems>();
            ToInstantiateCookie.GetComponent<CookiesItems>().SetID(ToInstantiateCookie.GetInstanceID().ToString());
            ToInstantiateCookie.transform.position = _InnerPosition;
            ToInstantiateCookie.transform.SetParent(CookiesHolder.transform);
            RegisterNewType(ToInstantiateCookie.GetInstanceID().ToString(), _BoardParent);
        }
    }
}



