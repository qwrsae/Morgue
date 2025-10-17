using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class HospitalDoor : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Objects _needObject;
    [SerializeField] private string _message;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _hint;
    [SerializeField] private bool _destroyKey;
   
    private Animator _animator;
    private CameraController _camera;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _text.gameObject.SetActive(false);
        _camera = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (_inventory.Objects.Contains(_needObject))
                {
                    _animator.Play("OpenDoor");
                    if (_destroyKey)
                        _inventory.ClierSlot(_needObject);
                    _camera.Left = -10;
                    Destroy(this); 
                }
                else 
                {
                    _text.gameObject.SetActive(true);
                    _text.text = _message;
                }
                    
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController _))
        {
            _text.gameObject.SetActive(false);
            _hint.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController _))
            _hint.SetActive(true);
    }


}
