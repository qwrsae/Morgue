using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PikableObject : OutlineAction
{
    [SerializeField] protected Sprite selfImage;
    [SerializeField] protected Inventory inventory;
    [SerializeField] private Objects _object;

    private void OnMouseDown()
    {
        inventory.InputSlot(selfImage, _object);
        
        Destroy(gameObject);
    }
}

public enum Objects
{
    empty,pencil,key,doorkey
}