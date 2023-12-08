using UnityEngine;

// Class to create a Coin object with a basic rotation
public class Coin : MonoBehaviour
{
    private int score = 1;
    private float rotateSpeed = 50f;
    
    void Start() {
        transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
    }

    void Update() {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            gameObject.SetActive(false);
            GameMaster.instance.ScoreUp(score);
        }
    }
}
