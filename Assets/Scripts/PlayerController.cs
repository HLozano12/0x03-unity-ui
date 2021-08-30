using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary> Starts up the Player </summary>
public class PlayerController : MonoBehaviour
{
	public int score = 0;
	public int health = 5;
	public float speed = 5.0F;
	public Image endScreen;
    public Text endText;
    public Text scoreText;
    public Text healthText;

	public Rigidbody rb;

	void Start()
	{
		SetHealthText();
		rb = GetComponent<Rigidbody>();
	}

	void Update() 
	{
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
        }
    }

	///<summary> WASD or Arrow Keys uesed </summary>
	void FixedUpdate()
	{
		if ( Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if ( Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if ( Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if ( Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
	}

	void OnTriggerEnter(Collider other)
    {
		// should increment value of score
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            // Debug.Log($"Score: {score}");
			SetScoreText();
			Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
			SetHealthText();
            // Debug.Log($"Health: {health}");
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            SetWin();
			// Debug.Log("You win!");
        }
    }

	void SetScoreText()
	{
		scoreText.text = $"Score: {score}";
	}

	void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

	void SetWin()
    {
        endScreen.gameObject.SetActive(true);
        endScreen.color = Color.green;
        endText.text = "You Win!";
        endText.color = Color.black;
        StartCoroutine(LoadScene(3.0F));
    }
}