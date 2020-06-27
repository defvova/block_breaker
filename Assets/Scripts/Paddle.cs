using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    Vector2 paddlePos = new Vector2(0, 0);

    private void Start()
    {
        paddlePos.y = transform.position.y;
    }

    void Update()
    {
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        paddlePos.x = Mathf.Clamp(mousePosition, minX, maxX);
        transform.position = paddlePos;
    }
}
