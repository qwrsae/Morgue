using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _right;
    [SerializeField] private float _left;

    public float Left { get => _left; set { _left = value; } }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, transform.position.y,_player.position.z),
            _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x,
            transform.position.y, Mathf.Clamp(transform.position.z, _left, _right));
    }
}
