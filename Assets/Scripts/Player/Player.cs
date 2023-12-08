using UnityEngine;

public class Player : MonoBehaviour {
    private float raycastDistance = 1f;

    [SerializeField]
    private float chargedSpeed = 10f;

    private KeyCode chargePlayerSpeed = KeyCode.Space;

    private Rigidbody _rigidbody;

    private bool applyForwardForce;

    private bool gameStarted;

    public bool GameStarted {
        get {
            return gameStarted;
        }
    }

    private float xInput;

    private int coinLayer = 1 << 7;

    private float maxSpeed = 25000;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        xInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(chargePlayerSpeed) && !gameStarted) {
            chargedSpeed += 10;
        }
        if (Input.GetKeyUp(chargePlayerSpeed) && !gameStarted) {
            applyForwardForce = true;
            gameStarted = true;
        }
    }

    void FixedUpdate() {
        // If the player release the spacebar, a force will be applied to it in the Z axis of the world
        if (applyForwardForce) {
            // If the ammount of speed exceeds the maximum allowed. it will be set to the maximum.
            if (chargedSpeed > maxSpeed) {
                chargedSpeed = maxSpeed;
            }
            _rigidbody.AddForce(Vector3.forward * chargedSpeed, ForceMode.Force);
            _rigidbody.angularVelocity = Vector3.zero;
            applyForwardForce = false;
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
