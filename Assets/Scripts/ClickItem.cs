using System;
using UnityEngine;


public class ClickItem : MonoBehaviour
{
    private Vector3 _startScale;
    private float _posY;
    
    public void OnMouseUp()
    {
        GetComponent<Item>().SpawnIcon();

        Destroy(gameObject);
    }

    public void OnMouseDown()
    {
        GetComponent<Outline>().enabled = true;

        _startScale = transform.localScale;

    }

    private void Update()
    {
        if (transform.localScale.x < _startScale.x * 1.1f)
        {
            transform.localScale += _startScale * Time.deltaTime * 2f;
        }

    }
}