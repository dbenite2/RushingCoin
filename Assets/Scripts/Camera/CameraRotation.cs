using System.Collections;
using UnityEngine;

// Class to set the special rotation to the Camera
public class CameraRotation : MonoBehaviour {
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    public float rotationSpeed = 0.5f;
    public int maxRotations = 1;

    private int rotationsCount = 0;

    void Start() {
        initialRotation = transform.rotation;
        StartCoroutine(RotatePeriodically());
    }

    IEnumerator RotatePeriodically() {
        // It will execute based on the given ammount of rotations
        while (rotationsCount < maxRotations) {
            // Will wait for 7 seconds to start doing the initial rotation
            yield return new WaitForSeconds(7f);
            // Set the target rotation only in the Z axis and in  180 degrees
            targetRotation = initialRotation * Quaternion.Euler(0f, 0f, 180f);

            float elapsedTime = 0f;
            while (elapsedTime < rotationSpeed) {
                transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime / rotationSpeed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Wait for 3 seconds to rotate again to its original position
            yield return new WaitForSeconds(3f);
            // The previous targetRotation becomes the initialRotation position
            initialRotation = targetRotation;
            targetRotation = initialRotation * Quaternion.Euler(0f, 0f, 0f);

            elapsedTime = 0f;
            while (elapsedTime < rotationSpeed) {
                transform.rotation = Quaternion.Lerp(targetRotation, initialRotation, elapsedTime / rotationSpeed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rotationsCount++;
        }
    }
}
