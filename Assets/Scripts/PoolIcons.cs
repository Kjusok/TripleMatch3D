using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;

public class PoolIcons : MonoBehaviour
{
    private const int StartPositionX = -520;
    private const int NumberCells = 7;
    private const int StepXPos = 130;
    private const int PositionY = -588;
    private const int DoubleStep = 2;
    private const int ValueDestroy = 3;

    private List<string> _iconsID;
    private List<Icon> _icons;
    private List<Vector3> _positions;

    private int _indexFoundObject;
    private int _step = 1;

    private bool _isRepeatsOnce;
    private bool _isRepeatedTwice;

    private IconsHolder _iconsHolder;
    private Item _item;


    [Inject]
    public void Construct(IconsHolder iconsHolder)
    {
        _iconsHolder = iconsHolder;
    }

    private void Awake()
    {
        _icons = new List<Icon>();
        _iconsID = new List<string>();
        _positions = new List<Vector3>();

        CollectListPositions();
    }

    private void CollectListPositions()
    {
        var posX = StartPositionX;

        for (int i = 0; i < NumberCells; i++)
        {
            posX += StepXPos;

            _positions.Add(new Vector3(posX, PositionY));
        }
    }

    private void MoveIconRight(string id, Icon icon)
    {
        string valueToCheck = id;

        _indexFoundObject = _iconsID.FindIndex(obj => obj == valueToCheck);

        icon.ChangePosition(_positions[_indexFoundObject + _step]);

        for (int i = _icons.Count - 1; i >= _indexFoundObject + _step; i--)
        {
            _icons[i].ChangePosition(_positions[i + 1]);
        }
    }

    public void CheckContainsValue(string id, Icon icon)
    {
        _isRepeatsOnce = _iconsID.Contains(id);

        _isRepeatedTwice = CheckMultipleOccurrences(_iconsID, id);

        if (_isRepeatedTwice)
        {
            _step = DoubleStep;
            MoveIconRight(id, icon);

            return;
        }

        if (_isRepeatsOnce)
        {
            _step = 1;
            MoveIconRight(id, icon);
        }
    }

    private bool CheckMultipleOccurrences<T>(List<T> list, T item)
    {
        int count = list.Count(x => x.Equals(item));
        return count > 1;
    }

    private void SwapElementsInList()
    {
        for (int i = _iconsID.Count - 1; i >= _indexFoundObject + DoubleStep; i--)
        {
            Swap(_iconsID, i, i - 1);
            Swap(_icons, i, i - 1);
        }
    }

    private void Swap<T>(List<T> list, int i, int j)
    {
        (list[i], list[j]) = (list[j], list[i]);
    }

    private void CheckingThreeIdentical(string id)
    {
        int count = 0;

        foreach (string icon in _iconsID)
        {
            if (icon == id)
            {
                count++;

                if (count >= ValueDestroy)
                {
                    DestroyDuplicateElements(id);
                    MoveRemainingObjects();

                    _iconsHolder.SubtractFromCounter();

                    break;
                }
            }
        }
    }

    public void CollectElementsInLists(string id, Icon icons)
    {
        _iconsID.Add(id);
        _icons.Add(icons);

        if (_isRepeatsOnce)
        {
            SwapElementsInList();
        }

        CheckingThreeIdentical(id);
    }

    private void DestroyDuplicateElements(string id)
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

    private void MoveRemainingObjects()
    {
        for (int i = 0; i < _icons.Count; i++)
        {
            _icons[i].ChangePosition(_positions[i]);
        }
    }
}
