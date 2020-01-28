using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    private float minX;
    private float maxX;
    private float screenWidthInUnits;
    private SpriteRenderer paddleSprite;
    private Vector2 paddlePos;
    void Start()
    {
        paddleSprite = GetComponent<SpriteRenderer>();
        //finding paddle's size from center to left edge point that means half of the sprite width as units
        minX = paddleSprite.bounds.extents.x;
        //finding screen width as units
        screenWidthInUnits = Camera.main.transform.position.x + Camera.main.orthographicSize * Screen.width / Screen.height;
        //finding camera's right edge point then subtract half of the sprite's width
        maxX = screenWidthInUnits - minX;
    }

    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        paddlePos = new Vector2(transform.position.x, transform.position.y);
        //using mathf.clamp to define edges of our gameplay screen as units
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }

}
