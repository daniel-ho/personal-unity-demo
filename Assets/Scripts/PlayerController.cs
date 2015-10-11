using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float rotationSpeed = 10.0F;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void Update ()
	{
		GameObject secretDoor = GameObject.Find("Secret Door");
		if (count == 4)
		{
			secretDoor.gameObject.SetActive (false);
		}
	}

	void FixedUpdate ()
	{
		float rotation = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (0.0f, 0.0f, moveVertical);
		rb.AddRelativeForce (movement * speed, ForceMode.Acceleration);

		transform.Rotate(0,rotation,0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag ("Secret Door") && count == 4)
		{
			other.gameObject.SetActive (false);
		}
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count == 5)
			winText.text = "You Win!";
	}
}