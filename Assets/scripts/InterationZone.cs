using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class InterationZone : MonoBehaviour
{
    [SerializeField] private GameObject _hint;
    [SerializeField] private Camera _camera;
    [SerializeField]private TMP_Text _messageText;
    [SerializeField] private string _message;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Objects _needObjects;
    

    private bool _isAction;
    private Camera _mainCamera;
    private CabinetDoor _door;
    private bool _inTable;    
    void Start()
    {
        _hint.SetActive(false);
        _mainCamera = Camera.main;
        _camera.enabled = false;
        _door= GetComponentInChildren<CabinetDoor>();
        if (_door != null)
        {
            _messageText.gameObject.SetActive(false);
            _door.InjectDependencies(_inventory, _needObjects, _messageText,_message);

        }
    }

    private void TableAction(PlayerController player)
    {
        _inTable = !_inTable;
        player.enabled = !_inTable;
        _mainCamera.enabled = !_inTable;
        _camera.enabled = _inTable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController _))
            _hint.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (Input.GetKey(KeyCode.E) && !_isAction)
            {
                TableAction(player);
                StartCoroutine(Delay());
                
            }
        }
    }
    private IEnumerator Delay()
    {
        _isAction = true;
        yield return new WaitForSeconds(0.2f);
        _isAction = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hint.SetActive(false);
            _messageText.gameObject.SetActive(false);
        }
    }
}
