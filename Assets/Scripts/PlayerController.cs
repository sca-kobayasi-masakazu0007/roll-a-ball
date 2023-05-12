using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int score;
    private int upForce;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upForce = 200;
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector3(0, upForce, 0));
        }

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Ground")
            isGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Ground")
            isGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            score = score + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        scoreText.text = "Count: " + score.ToString();

        if(score >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
