using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    [Range(0, 20)] public float WalkingSpeed = 6f;

    private Rigidbody2D _playerRigidBody;

    void Awake() {
        Debug.Assert(GetComponent<Rigidbody2D>() != null);
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        _playerRigidBody.velocity = new Vector2(
            Mathf.Lerp(0, Input.GetAxis("Horizontal") * WalkingSpeed, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical") * WalkingSpeed, 0.8f)
            );
    }
}
