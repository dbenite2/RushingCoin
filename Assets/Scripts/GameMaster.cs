using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMaster : MonoBehaviour
{
public GameObject plane; // Assign your Plane GameObject here in the inspector
public GameObject yourObject; // Assign your GameObject here in the inspector

void Start()
{
    Vector3 planeSize = plane.GetComponent<Renderer>().bounds.size; // Get the size of the Plane
    Vector3 planePos = plane.transform.position; // Get the position of the Plane

    // Position your object at the right border of the Plane
    yourObject.transform.position = new Vector3(planePos.x , planePos.y + 0.5f, (planePos.z - planeSize.z / 2) + 5);
}
}
