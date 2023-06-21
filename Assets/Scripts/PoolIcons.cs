using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Zenject;

public class PoolIcons : MonoBehaviour
{
    [SerializeField] private List<string> _iconsID;
    private int _posX;
    

    [SerializeField] private List<Icon> _icons;

    [SerializeField] private List<Vector3> _posList; 
    

    private IconsHolder _iconsHolder;
    private Item _item;
    private bool _containsValue;
    private int _foundObject;

    [Inject]
    public void Construct(IconsHolder iconsHolder)
    {
        _iconsHolder = iconsHolder;
    }

    private void Awake()
    {
        _icons = new List<Icon>();
        _iconsID = new List<string>();
        _posList = new List<Vector3>();


        var posX = -520;
        for (int i = 0; i < 7; i++)
        {
            posX += 130;
            _posList.Add(new Vector3(posX, -588));
        }
    }



    public void CheckContainsValue(string id, Icon icon)
    {
        _containsValue = _iconsID.Contains(id);
        
        if (_containsValue)
        {
            string valueToCheck = id;
            
           _foundObject = _iconsID.FindIndex(obj => obj == valueToCheck);

           
           
               icon.ChangePosition(_posList[_foundObject + 1]);
               
               for (int i = _icons.Count - 1; i >= _foundObject+1; i--)
               {
                   _icons[i].ChangePosition(_posList[i + 1]);
               }

        }
    }

    private void ChangeElements()
    {

        if (_containsValue)
        {
            for (int i = _iconsID.Count - 1; i >= _foundObject + 2; i--)
            {
                Swap(_iconsID, i, i - 1);
                Swap(_icons, i, i - 1);
            }
        }
    }

    private void Swap<T>(List<T> list, int i, int j)
    {
        (list[i], list[j]) = (list[j], list[i]);
    }
    
    public void AddIDToList(string id, Icon icons)
    {
        
        _iconsID.Add(id);
        _icons.Add(icons);

       ChangeElements();

        
        int count = 0;

        foreach (string icon in _iconsID)
        {
            if (icon == id)
            {
                count++;

                if (count >= 3)
                {
                    RemoveFromList(id);
                    _iconsHolder.Minus();

                    RemoveLine();

                    break;
                }
            }
        }
    }

    private void RemoveFromList(string id)
    {
        for (int i = _iconsID.Count - 1; i >= 0; i--)
        {
            if (_iconsID[i] == id)
            {
                _iconsID.RemoveAt(i);
                _icons[i].DestroyIcon();
                _icons.RemoveAt(i);

            }
        }
    }

   private void RemoveLine()
    {
        for (int i = 0; i < _icons.Count; i++)
        {
            _icons[i].ChangePosition(_posList[i]);
        }
    }
}
