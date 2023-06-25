using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CollectItems3D : MonoBehaviour
    {
        private List<Item3D> _itemsClickList;


        private void Awake()
        {
            _itemsClickList = new List<Item3D>();
        }

        public void AddToList(Item3D item3D)
        {
            _itemsClickList.Add(item3D);
        }
    }
}