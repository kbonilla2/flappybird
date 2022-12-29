using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //need to create a reference to access other components in the inspector besides name & transform
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            myRigidBody.velocity = Vector2.up * flapStrength;
            anim.SetBool("isJumping", true);

        }

        if(Input.GetKeyUp(KeyCode.Space)) {
            anim.SetBool("isJumping", false);
        }

        if (transform.position.y > 16.3 || transform.position.y < -16.3) {
            logic.gameOver();
            birdIsAlive = false;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        birdIsAlive = false;
    }
}
