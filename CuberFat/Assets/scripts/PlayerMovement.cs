using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rigid;
    Animator anim;
    PlayerInput plInput;

    public float speed = 15;
    public float rotSpeed = 30;
    public bool canMove = true;

    bool lookLeft;

    //Quaternion originalRot;
    Quaternion targetRot;

    void Start ()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        plInput = GetComponent<PlayerInput>();
    }
	
	
	void FixedUpdate ()
    {
        if (canMove)
        {
            Vector3 horizontalForse = Vector3.right * plInput.hotizontal;
            Vector3 verticalForce = Vector3.forward * plInput.vertical;
            rigid.AddForce((horizontalForse + verticalForce).normalized * speed);

            UpdateAnimator();

            if(plInput.hotizontal != 0)
            {
                lookLeft = (plInput.hotizontal < -.01f) ? true : false;
        
            }
            if (lookLeft)
            {
                targetRot = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                targetRot = Quaternion.Euler(0, 0, 0);
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotSpeed);
        }
	}
    void UpdateAnimator()
    {
        anim.SetFloat("Horizontal", Mathf.Abs(plInput.hotizontal));
        anim.SetFloat("Vertical", (lookLeft) ? -plInput.vertical : plInput.vertical);
    }
}
