using UnityEngine;

public class IconsHolder : MonoBehaviour
{
    private int _posX;
    private int _posY;
    private int _counter;

    public void AddToCounter()
    {
        _counter++;
    }

    public void SubtractFromCounter()
    {
        _counter -= 3;
    }
    
    public Vector2 TargetPosition()
    {
        _posX = -390;
        _posY = -588;
        for (int i = 1; i < _counter; i++)
        {
            _posX += 130;
        }
        
        return new Vector2(_posX, _posY);
    }
}