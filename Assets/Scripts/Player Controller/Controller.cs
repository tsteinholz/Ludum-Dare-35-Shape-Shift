using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    [Range(0, 20)] public float WalkingSpeed = 6f;

    private Rigidbody2D _playerRigidBody;
    private Vector2 _veloctiy;

    void Awake() {
        Debug.Assert(GetComponent<Rigidbody2D>() != null);
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Start () {

    }

    void FixedUpdate () {
        _veloctiy.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _veloctiy = _veloctiy.normalized * WalkingSpeed * Time.deltaTime;
        _playerRigidBody.MovePosition(_playerRigidBody.position + _veloctiy);
    }
}
