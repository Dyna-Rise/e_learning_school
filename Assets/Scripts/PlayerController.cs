using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static string gameState;

    public float jumpPower = 0.2f;
    public float shrinkSpeed = 0.5f; // 縮小速度
    public GameObject goal;

    float jump;
    Vector2 v;
    bool isGround = false;
    bool inGoal = false;

    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        gameState = "playing";
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState != "playing")
        {
            return;
        }

        jump = Input.GetAxis("Jump");

    }

    void FixedUpdate()
    {
        if (isGround)
        {
            if (jump > 0)
            {
                v = new Vector2(0, jump * jumpPower);
                rbody.AddForce(v, ForceMode2D.Impulse);
            }
        }

        if (inGoal)
        {
            // プレイヤーを徐々に小さくする
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            // 完全に消えたらオブジェクトを非アクティブにする
            if (transform.localScale.x <= 0.01f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Dead")
        {
            gameState = "gameOver";
            Destroy(gameObject);
        }
        
        if(collision.gameObject.tag == "Goal")
        {
            gameState = "gameClear";
            inGoal = true;

            transform.position = goal.transform.position;
            rbody.velocity = Vector2.zero;
            rbody.isKinematic = true;
        }
    }
}
