using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;

    string input;
    bool isRight;

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;

        Vector2 offset = new Vector2(transform.localScale.x, 0);

        if (isRightPaddle)
        {
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= offset;

            input = "PaddleRight";
        }
        else
        {
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += offset;

            input = "PaddleLeft";
        }

        transform.position = pos;

        transform.name = input;
    }

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.started)
        {
            Init(isRight);
        }

        bool canMove = false;

        float offset = (height + (transform.localScale.x / 2)) / 2;

        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (move > 0 && transform.localPosition.y + offset < GameManager.topRight.y)
        {
            canMove = true;
            GameManager.started = true;
        }
        else if (move < 0 && transform.localPosition.y - offset > GameManager.bottomLeft.y)
        {
            canMove = true;
            GameManager.started = true;
        }

        if (canMove)
        {
            transform.Translate(move * Vector2.up);
        }
    }
}
