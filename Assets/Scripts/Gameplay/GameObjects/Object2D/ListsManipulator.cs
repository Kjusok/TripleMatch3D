using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ListsManipulator : MonoBehaviour
    {
        [SerializeField] private List<Transform> _position;
        
        private const int DoubleStep = 2;

        private Item3D _item3D;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private Mover2DItems _mover2DItems;

        public List<string> ItemsIDList { get; private set; }
        public List<Item2D> ItemsList { get; private set; }
        public List<Transform> PositionsList => _position;


        private void Awake()
        {
            ItemsList = new List<Item2D>();
            ItemsIDList = new List<string>();

            _checkerDuplicate2dItems = GetComponent<CheckerDuplicate2dItems>();
            _mover2DItems = GetComponent<Mover2DItems>();
        }

        private void SwapElementsInList()
        {
            for (int i = ItemsIDList.Count - 1; i >= _mover2DItems.IndexFoundObject + DoubleStep; i--)
            {
                Swap(ItemsIDList, i, i - 1);
                Swap(ItemsList, i, i - 1);
            }
        }

        private void Swap<T>(List<T> list, int i, int j)
        {
            (list[i], list[j]) = (list[j], list[i]);
        }

        public void CollectElementsInLists(string id, Item2D item2Ds)
        {
            ItemsIDList.Add(id);
            ItemsList.Add(item2Ds);

            if (_checkerDuplicate2dItems.IsRepeatsOnce)
            {
                SwapElementsInList();
            }

            _checkerDuplicate2dItems.CheckingThreeIdentical(id);
        }

        public void RemoveAndDestroyDuplicateElements(string id)
        {
            for (int i = ItemsIDList.Count - 1; i >= 0; i--)
            {
                if (ItemsIDList[i] == id)
                {
                    ItemsIDList.RemoveAt(i);

                    ItemsList[i].DestroyIcon();
                    ItemsList.RemoveAt(i);
                }
            }
        }
    }
}
