using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameStatus gm;
    Ball ball;
    Vector2 paddlePos = new Vector2(0, 0);

    private void Start()
    {
        gm = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
        paddlePos.y = transform.position.y;
    }

    void Update()
    {
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gm.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
