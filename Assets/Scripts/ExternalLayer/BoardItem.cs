using UnityEngine;

namespace UseCases
{
    public class BoardItem : MonoBehaviour, IBoardItemType
    {
        // 0 = void Type , 1 = Floor type
        private int  ItemTagType = 1;
        private void Awake()
        {
            Delegates.Register_OnMapCreated += OnRegisterMapCall;
            Delegates.Register_OnResetBoardItems += OnResetScene;
        }
        private void OnDisable()
        {
            Delegates.Register_OnMapCreated -= OnRegisterMapCall;
            Delegates.Register_OnResetBoardItems -= OnResetScene;
        }
        public void OnRegisterMapCall()
        {
            if (ItemTagType == 2)
            {
                IBoardItemType mToSend = this;
                Services.Instance.GetService<ICookiesSpawner>().GrabableItem(gameObject.transform.position + (Vector3.up), mToSend);
            }
            gameObject.GetComponent<MeshRenderer>().enabled = ItemTagType == 1 || ItemTagType == 2;
            gameObject.GetComponent<Collider>().enabled     = ItemTagType == 1 || ItemTagType == 2;

            
        }

        private void OnResetScene()
        {
            ItemTagType = 1;
            OnRegisterMapCall();
        }
        public void SetItemTag(int _TagType)
        {
            ItemTagType = _TagType;
        }

        public string GetItemID()
        {
            return gameObject.GetInstanceID().ToString();
        }

        public int GetItemBoardType()
        {
            return ItemTagType;
        }

        public void SetPointExternal()
        {
            if (ItemTagType == 2)
            {
                IBoardItemType mToSend = this;
                Services.Instance.GetService<ICookiesSpawner>().GrabableItem(gameObject.transform.position + (Vector3.up), mToSend);
            }
            
        }
    }
}

