using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;

    public bool isAllowedToMove = true;


	// Use this for initialization
	void Start () {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        if (isAllowedToMove)
        {

            Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("Is_Walking", true);
                anim.SetFloat("input_x", movement_vector.x);
                anim.SetFloat("input_y", movement_vector.y);
            }
            else
            {
                anim.SetBool("Is_Walking", false);
            }

            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * 5);
        }
		
	}
}
