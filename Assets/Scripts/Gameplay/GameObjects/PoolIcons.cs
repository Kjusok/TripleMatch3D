using System.Collections.Generic;
using UnityEngine;


//   //перемешивает список-метод логики перемешивания списка
//    //добавляет в лист объекты которые пополи в пул и далее перемещивает или проверяет на сораность тройки
//    //уничтожает дублированые объекты


namespace Gameplay
{
    public class PoolIcons : MonoBehaviour
    {
        private const int StartPositionX = -520;
        private const int NumberCells = 7;
        private const int StepXPos = 130;
        private const int PositionY = -588;
        private const int DoubleStep = 2;

        public List<string> ItemsIDList
        {
            get; private set;
        }
        public List<Item2D> ItemsList{
            get; private set;
        }
        public List<Vector3> PositionsList
        {
            get; private set;
        }

        private int _indexFoundObject;
        private int _step = 1;

        private bool _isRepeatsOnce;
        private bool _isRepeatedTwice;

        private Item3D _item3D;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
       

        private void Awake()
        {
            ItemsList = new List<Item2D>();
            ItemsIDList = new List<string>();
            PositionsList = new List<Vector3>();

            _checkerDuplicate2dItems = GetComponent<CheckerDuplicate2dItems>();

            CollectListPositions();
        }

        private void CollectListPositions()
        {
            var posX = StartPositionX;

            for (int i = 0; i < NumberCells; i++)
            {
                posX += StepXPos;

                PositionsList.Add(new Vector3(posX, PositionY));
            }
        }



        private void SwapElementsInList()
        {
            for (int i = ItemsIDList.Count - 1; i >= _indexFoundObject + DoubleStep; i--)
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

            if (_isRepeatsOnce)
            {
                SwapElementsInList();
            }

            _checkerDuplicate2dItems.CheckingThreeIdentical(id);
        }

        public void DestroyDuplicateElements(string id)
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

