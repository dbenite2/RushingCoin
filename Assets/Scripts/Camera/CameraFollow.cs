using UnityEngine;

// Class to follow the player
public class CameraFollow : MonoBehaviour {
   [SerializeField]
   private Transform _player;

   [SerializeField]
   private int xAxis;

   [SerializeField]
   private int yAxis;

   [SerializeField]
   private int zAxis;

   void LateUpdate() {
        transform.position = _player.transform.position + new Vector3(xAxis,yAxis, zAxis);
   }
}
