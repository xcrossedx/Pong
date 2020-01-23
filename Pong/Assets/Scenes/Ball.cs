using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        SetDirection();
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.started)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (transform.localPosition.y > GameManager.topRight.y - radius || transform.localPosition.y < GameManager.bottomLeft.y + radius)
        {
            direction.y = -direction.y;

            if (direction.x >= 0f && direction.x < 0.25f)
            {
                direction.x = Random.Range(0.3f, 0.5f);
            }
            else if (direction.x < 0f && direction.x > -0.25f)
            {
                direction.x = Random.Range(-0.3f, -0.5f);
            }
        }
    }

    private void SetDirection()
    {
        direction = new Vector2(Random.Range(-0.10f, 0.10f), Random.Range(-1.0f, 1.0f)).normalized;
    }
}
