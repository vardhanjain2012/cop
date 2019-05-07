using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using TMPro;

public class PlayerMovement : MonoBehaviour {

    private CharacterController character_Controller;
    private PlayerStats p1;
    GameObject pp;
    private Vector3 move_Direction;

    public float fruit_gain=7f;

    public float speed = 5f;
    private float gravity = 20f;

    public float jump_Force = 10f;
    private float vertical_Velocity;
    void Start()
    {
        pp = GameObject.FindWithTag("Player");
        p1 = pp.GetComponent<PlayerStats>();
        if (p1 == null)
        {
            Debug.Log("dfdd");
        }
    }
    void Awake() {
        character_Controller = GetComponent<CharacterController>();
    }
	
	void Update () {
        MoveThePlayer();
	}

    void MoveThePlayer() {

        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f,
                                     Input.GetAxis(Axis.VERTICAL));

        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        ApplyGravity();

        character_Controller.Move(move_Direction);


    } // move player

    void ApplyGravity() {

        vertical_Velocity -= gravity * Time.deltaTime;

        // jump
        PlayerJump();

        move_Direction.y = vertical_Velocity * Time.deltaTime;

    } // apply gravity

    void PlayerJump() {

        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            vertical_Velocity = jump_Force;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {

            other.gameObject.SetActive(false);
            if (p1.health_Stats.fillAmount + (fruit_gain/100f) > 1f)
            {
                p1.health_Stats.fillAmount = 1f;
            }
            else
            {
                p1.health_Stats.fillAmount = p1.health_Stats.fillAmount + (fruit_gain / 100f);
            }
            // count = count + 1;
            //CountUpdate();
        }
    }

} // class


































