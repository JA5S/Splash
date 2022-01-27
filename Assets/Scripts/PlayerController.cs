using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moves player and deals with player collision
public class PlayerController : MonoBehaviour
{
    //declare variables
    public GameManager gameManager;
    public WaterMeter waterMeter;

    private AudioSource playerAudio;
    public AudioClip splashSound;

    public Rigidbody2D rBody;
    public float moveSpeed = 5f;
    private Vector2 xInput;

    private Vector2 pos;
    private float scrWth;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        GetScreenWidth();
    }

    void Update()
    {
        MovePlayer();
        ScreenWrap();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Drop"))
        {
            waterMeter.IncreaseWater();
            Destroy(collision.gameObject);
            playerAudio.PlayOneShot(splashSound);
        }
    }

    //calc screen width in units from pixels
    void GetScreenWidth()
    {
        scrWth = Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height;
    }

    //horizontal player movement
    void MovePlayer()
    {
        if (!waterMeter.gameOver &&  gameManager.gameHasStarted)
        {
            xInput.x = Input.GetAxis("Horizontal");
            rBody.MovePosition(rBody.position + xInput * moveSpeed * Time.deltaTime);
        }
    }

    //have the player screen wrap from right to left side of screen and visa versa
    void ScreenWrap()
    {
        pos = transform.position;

        //right side
        if (pos.x - 0.5f > scrWth)
        {
            pos.x = -pos.x + 0.1f;
        }
        //left side
        else if (pos.x + 0.5f < -scrWth)
        {
            pos.x = -pos.x - 0.1f;
        }

        transform.position = pos;
    }
}
