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
    public float upForce;

    private Rigidbody rb;
    private int score;
    private bool isGround = true;
    private int pickUpCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upForce = 200;
        score = 0;
        pickUpCount = 0;
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
            isGround = false;
        }

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            score += 1;
            pickUpCount += 1; 
            SetCountText();
        }
    }

    void SetCountText()
    {
        scoreText.text = "Count: " + score.ToString();

        if(score >= 21)
        {
            winText.text = "You Win!";
        }
    }

    void PickUpOn(Collider other)
    {
        var PickUp2 = other.gameObject.CompareTag("Pick Up2");
        other.gameObject.SetActive(false);

    }
}
