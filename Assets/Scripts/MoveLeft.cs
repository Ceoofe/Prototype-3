using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController PlayerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 60;
        }
        else
        {
            speed = 30;
        }
        if (PlayerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                PlayerController.score += 2;
            }
            else
            {
                PlayerController.score += 1;
            }
            Debug.Log("Score: " + PlayerController.score);
            Destroy(gameObject);
        }
    }
}
