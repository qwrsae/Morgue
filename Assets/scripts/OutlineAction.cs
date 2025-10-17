using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineAction : MonoBehaviour
{

    private Outline _outline;
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }


    private void OnMouseEnter()
    {
        _outline.enabled = true;
    }

    private void OnMouseExit()
    {
        _outline.enabled = false;
    }

   
}
