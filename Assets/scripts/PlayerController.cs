using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float  _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _rotSpeed;
    private CharacterController _controller;
    private Camera _camera;
    private Vector3 _motion;
    private Vector3 _camForward;
    private Animator _anim;
    void Start()
    {
        _camera = Camera.main;
        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
        Gravity();
        Rotation();
    } 
    private void Move()
    {
        _motion.x = Input.GetAxis("Horizontal");
        _motion.z = Input.GetAxis("Vertical");

        _camForward = _camera.transform.forward;
        _camForward.y = 0;
        _motion = Quaternion.LookRotation(_camForward) * _motion;
        _controller.Move(_motion * _speed * Time.deltaTime);

        if (_motion.x != 0 ||
            _motion.z != 0)
        {
            _anim.SetBool("walk",true);
        }
        else
        {
            _anim.SetBool("walk", false);
        }
    }
    private void Gravity()
    {
        if (!_controller.isGrounded)
            _motion.y -= _gravity * Time.deltaTime;
    }
    private void Rotation()
    {
        _motion = transform.InverseTransformDirection(_motion);
        float turn = Mathf.Atan2(_motion.x, _motion.z);
        transform.Rotate(0, turn * _rotSpeed, 0);
    }
}
