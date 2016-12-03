using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    public float hotizontal;
    public float vertical;
    public bool fire1;
	void Start () {
	
	}
	
	
	void FixedUpdate ()
    {
        this.hotizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");
        this.fire1 = Input.GetButton("Fire1");
	}
}
