using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using TMPro;

public class CabinetDoor : OutlineAction
{
    private Inventory _inventory;
    private Objects _needObject;
    private TMP_Text _messageText;
    private string _message;

    public void InjectDependencies(Inventory inventory,Objects obj,TMP_Text text,string message)
    {
        _inventory = inventory;
        _needObject = obj;
        _messageText = text;
        _message = message;
    }

    private void OnMouseDown()
    {
        if (_inventory.Objects.Contains(_needObject) )
        {
            if (_needObject != Objects.empty)
            {   
                _inventory.ClierSlot(_needObject);
                GetComponent<Animator>().Play("OpenDoor");
                GetComponent<Outline>().enabled = false;
                Destroy(this);
            }
        }
        else
        {
            _messageText.gameObject.SetActive(true);
            _messageText.text = _message;
        }   
    }
}
