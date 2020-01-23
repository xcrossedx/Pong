using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //creating the ball and paddles
    public Ball ball;
    public Paddle paddle;

    //Getting the screen dimensions
    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    //Game variables
    public static bool started = false;
    public static int score1 = 0;
    public static int score2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Instantiate(ball);

        Paddle pad1 = Instantiate(paddle) as Paddle;
        Paddle pad2 = Instantiate(paddle) as Paddle;

        pad1.Init(true); //Right paddle
        pad2.Init(false); //Left paddle
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
