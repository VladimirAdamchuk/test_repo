using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform target;
    public float speed;
    internal static UnityEngine.Camera main;

    void FixedUpdate ()
    {
        Vector3 pos = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        transform.position = pos;
	}
}
