using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    //to link paddle and ball
    [SerializeField] PaddleMove paddle1;
    [SerializeField] float ballVelX = 2f;
    [SerializeField] float ballVelY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    
    private bool isStarted = false;
    private Vector2 paddleToBallVector;

    //Cached components
    private AudioSource myAudioSource;
    private AudioClip clip;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            LockBallToPaddle();
            LaunchOnLeftClick();
        }
        
    }

    private void LaunchOnLeftClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(ballVelX,ballVelY);
            isStarted = true;
        }     
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = paddle1.transform.position;
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
        if(isStarted) myAudioSource.PlayOneShot(clip);
    }
}
