using UnityEngine;


public class GameMaster : MonoBehaviour {

    public static GameMaster instance;
    
    [SerializeField]
    private GameObject plane;

    [SerializeField]
    private Player player;

    private int score = 0;
    private Rigidbody _playerRigidBody;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(instance);
        }
    }

    void Start() {
        Vector3 planeSize = plane.GetComponent<Renderer>().bounds.size; // Get the size of the Plane
        Vector3 planePos = plane.transform.position; // Get the position of the Plane
        _playerRigidBody = player.GetComponent<Rigidbody>();

        // Position the player at the right border of the Plane
        player.transform.position = new Vector3(planePos.x , planePos.y + 0.5f, (planePos.z - planeSize.z / 2) + 5);
    }

    private void Update() {
        if (_playerRigidBody.velocity.z == 0 && player.GameStarted) {
            Debug.Log("You're score is: " + score);
        }
    }

    public void ScoreUp(int scoreToAdd) {
        score += scoreToAdd;
    }
}
