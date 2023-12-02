using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float raycastDistance = 1f;
    [SerializeField]
    private float chargedSpeed = 100f;

    [SerializeField]
    private GameObject _terrain;

    private KeyCode chargePlayerSpeed = KeyCode.Space;

    private Rigidbody _rigidbody;
    private bool applyForwardForce;
    private bool suddenStop;
    private float xInput;
    private int coinLayer = 1 << 7;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        xInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.Space)) {
            suddenStop = true;
            chargedSpeed += 100;
        }
        if (Input.GetKeyUp(chargePlayerSpeed)) {
            applyForwardForce = true;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            suddenStop = true;
        }

    }

    void FixedUpdate() {
        if (applyForwardForce) {
            _rigidbody.AddForce(Vector3.forward * chargedSpeed, ForceMode.Force);
            _rigidbody.angularVelocity = Vector3.zero;
            chargedSpeed = 100f;
            applyForwardForce = false;
        }
        if (suddenStop) {
            _rigidbody.velocity = Vector3.zero;
            suddenStop = false;
        }
        _rigidbody.AddForce(new Vector3(xInput, 0, 0) * _rigidbody.velocity.z);
        detectCollision();
    }

    private void detectCollision() {
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, transform.right, out hit, raycastDistance, coinLayer) ||
                     Physics.Raycast(transform.position, -transform.right, out hit, raycastDistance, coinLayer);

        if (isHit) {
            // If either ray hits something, apply a force in the opposite direction
            Vector3 reboundDirection = hit.point - transform.position;
            reboundDirection.y = 0;  // Consider only horizontal direction
            _rigidbody.AddForce(-reboundDirection.normalized * (_rigidbody.velocity.z * 0.5f), ForceMode.Impulse);
        }
    }
}
