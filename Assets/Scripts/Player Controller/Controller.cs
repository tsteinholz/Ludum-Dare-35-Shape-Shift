using UnityEngine;
using System.Collections;

/**
goals: 
    [] move player with WASD
    [] rotate player (always looking at mouse)
    [] handle physics
**/

public class Controller : MonoBehaviour {

    [Range(0, 20)] public float WalkingSpeed = 6f;
    [Range(0, 20)] public float RunningSpeed = 9f;

    public enum State {
        Idle,
        Walking,
        Running,
        Attacking
    }

    private State _characterState;
    private Rigidbody2D _playerRigidBody;
    private Vector2 _movement;

    void Awake()
    {
        if (GetComponent<Rigidbody2D>() != null)
            _playerRigidBody = GetComponent<Rigidbody2D>();
        else
            Debug.Log("No RigidBody Found!");
       
        _characterState = State.Idle;
    }

    void Start () {
	
	}
	
	void FixedUpdate () {
	
	}
}
