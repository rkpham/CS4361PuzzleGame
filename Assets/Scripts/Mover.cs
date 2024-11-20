using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //[SerializeField] float x = 0.01f;
    //[SerializeField] float y = 0.01f;
    //[SerializeField] float z = 0.0f;

    [SerializeField] float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(1,0,0);
        printInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void printInstruction()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move the player with the WASD or arrow keys");
        Debug.Log("Be careful not to hit the walls");
    }

    void movePlayer()
    {
        //transform.Translate(x,y,z);
        // z moves in and out of screen.
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(x,0,z);
    }
}
