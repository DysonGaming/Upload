using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    // -- Important movement/position vars

    AudioSource audioData;

    public Rigidbody PlayerRb;
    public Transform playerPos;
    public Vector3 offset;

    public GameController EndGame;

    float HorizontalValue = 0f;
    float PlayerSideSpeed = 45f;
    float PlayerFowardSpeed = 40f;
    float Sbonus = 0f;
    float Jbonus = 0f;

    // -- Game Vars & Init Stats

    bool playerAlive = true;

    bool move = false;
    public bool IsGrounded = false;
    int tick = 0;
    float OldTime;

    // change this value to get desired smoothness
    public float SmoothTime = 0.01f;
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        tick = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (EndGame.gamePlaying) 
        {
            if (Input.GetAxis("Horizontal") != 0 ) {
                move = true;
                // Set Value of Horizontal movement
                HorizontalValue = Input.GetAxis("Horizontal") * PlayerSideSpeed;
            } else {move = false;}

            if (move && playerAlive) {

                PlayerRb.AddForce(HorizontalValue * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }         


            // acceleration Script

            if (Time.time > OldTime)
            {
                if (tick != 7) 
                {
                    tick = tick + 1;
                    OldTime = Time.time + 10; // +10 = the time that is waited between speed increase
                } 
            
            }

            switch(tick)
            {
                case 1:
                    PlayerFowardSpeed = 30f + Sbonus;
                    break;

                case 2:
                    PlayerFowardSpeed = 30f + Sbonus;
                    break;

                case 3:
                    PlayerFowardSpeed = 30f + Sbonus;
                    break;

                case 4:
                    PlayerFowardSpeed = 35f + Sbonus;
                    break;

                case 5:
                    PlayerFowardSpeed = 35f + Sbonus;
                    break;

                case 6:
                    PlayerFowardSpeed = 40f + Sbonus;
                    break;

                case 7: // Super speed
                    PlayerFowardSpeed = 45f + Sbonus;
                    break;
            }

            // Move player foward(+script) and Make PlayerCam follow position of player (if player is alive)

            if (playerAlive) {

                // Stop move if player is jumping
                if (Jbonus == 0) {
                    // Player move 
                    PlayerRb.AddForce(0, 0, PlayerFowardSpeed * Time.deltaTime, ForceMode.VelocityChange);
                }

                // Player Jump
                PlayerRb.AddForce(0, Jbonus * Time.deltaTime, 0, ForceMode.Impulse);

                // update position
                Vector3 targetPosition = transform.position + offset;
                playerPos.position = Vector3.SmoothDamp(playerPos.position, targetPosition, ref velocity, SmoothTime);

                // Handle Bonuses
                StartCoroutine(BonusHandler());
            }
        }
    }

    IEnumerator BonusHandler() 
    {
        // SpeedPad
        while(Sbonus != 0) 
        {
            yield return new WaitForSeconds(1.25f);

            Sbonus = 0;
        }  

        while(Jbonus != 0) 
        {
            yield return new WaitForSeconds(0.35f);

            Jbonus = 0;
        }      
    }


    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.gameObject.name == "Obstacle")
        {
            Debug.Log("DEAD");
            playerAlive = false;
            EndGame.GameOver();
        }

        if (collisionInfo.gameObject.name == "Board")
        {
            IsGrounded = true;
        }

        if (collisionInfo.gameObject.name == "SpeedPad")
        {
            Sbonus = 75f;
        }

        if (collisionInfo.gameObject.name == "JumpPad")
        {
            Jbonus = 75f;
        }
    }

    void OnCollisionExit(Collision collisionEndInfo)
    {
        if (collisionEndInfo.gameObject.name == "Board")
        {
            IsGrounded = false;
        }
    }
}