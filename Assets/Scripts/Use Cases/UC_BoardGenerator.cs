using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace UseCases
{
    public class UC_BoardGenerator : MonoBehaviour
    {
        [SerializeField] private int RowsCount;
        [SerializeField] private int ColumsCount;
        [SerializeField] private int VoidCount;
        [SerializeField] private int GrabableCount;
        [SerializeField] private BoardItem BoardItemPrefab;
        [SerializeField] private GameObject PlayerObject;
        public static readonly Dictionary<string, IBoardItemType> BoardItemsList = new Dictionary<string, IBoardItemType>();

        private void OnEnable()
        {
            Delegates.Register_OnResetScene += OnResetScene;
        }
        private void OnDisable()
        {
            Delegates.Register_OnResetScene -= OnResetScene;
        }

        private void Start()
        {
            GenerateMapGrid();
        }

        private void GenerateMapGrid()
        {
            Vector3 SpawnPosition = Vector3.zero;
            GameObject mParentalHolder = new GameObject("Grid Parent Holder");
            mParentalHolder.transform.position = SpawnPosition;
            
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumsCount; j++)
                {
                    SpawnPosition.x = i;
                    SpawnPosition.z = j;

                    IBoardItemType  mToAddInstance =   Instantiate(BoardItemPrefab,SpawnPosition,Quaternion.identity,mParentalHolder.transform);
                    string mItemID = mToAddInstance.GetItemID();


                    if(!BoardItemsList.ContainsKey(mItemID))
                        BoardItemsList.Add(mItemID,mToAddInstance);

                }
            }
            //this Means = Void Types Tiles are set , The default Filter is 1 wich means a visible cube item and the new value is 0 , wich means a void type.
            GenerateBoardItems(VoidCount,1,0);

            //This means = Grabable cookies over visible tiles , 1 =  visible Tile  & 0 = invisible. 2 = means , that Board item , must have a Cookie over it!
            GenerateBoardItems(GrabableCount, 1, 2);
            
            Delegates.Register_OnMapCreated?.Invoke();
            SetPlayerOnBoard();
        }
        private void SetPlayerOnBoard()
        {
            PlayerObject.GetComponent<Rigidbody>().position = Vector3.up;
            PlayerObject.GetComponent<Rigidbody>().useGravity = true;
            PlayerObject.GetComponent<Rigidbody>().rotation = Quaternion.Euler(Vector3.zero);
        }

        private void GenerateBoardItems( int _Ciclelimit , int _ValueTypeFilter , int _NewValueType)
        {

            int mSelectedCounter = 0;
            while (mSelectedCounter < _Ciclelimit)
            {
                //we must to ensure that player shall be spawned , over a visible Point , so , thats why , random starts at point 1 instead 0 
                IBoardItemType mTemporalRandomVoidItem = BoardItemsList.ElementAt(Random.Range(1, BoardItemsList.Count)).Value;

                if (mTemporalRandomVoidItem.GetItemBoardType() == _ValueTypeFilter)
                {
                    mTemporalRandomVoidItem.SetItemTag(_NewValueType);
                    mSelectedCounter++;
                }
            }
        }

        private void OnResetScene()
        {
            Delegates.Register_OnResetBoardItems?.Invoke();
            GenerateBoardItems(VoidCount, 1, 0);
            GenerateBoardItems(GrabableCount, 1, 2);
            Delegates.Register_OnMapCreated?.Invoke();
            SetPlayerOnBoard();
        }
    }
}



