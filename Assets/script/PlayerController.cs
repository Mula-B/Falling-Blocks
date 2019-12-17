using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //snelheid speler
    public float speed = 7;

    public event System.Action OnPlayerDeath;
    
    float screenHalfWidthInWorldUnits;

	// Use this for initialization
	void Start () {

        //zorgt ervoor dat heel de speler niet voor de helft verdwijnt maar helemaal en weer te voor schijn komt aan de andere kant
        float halfPlayerWidth = transform.localScale.x / 2f;
        //berekening dat de speler niet verdwijnt uit het spel
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
		
	}
	
	// Update is called once per frame
	void Update () {
        //beweging speler
        float inputX = Input.GetAxisRaw ("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        //zorgt ervoor dat de speler niet uit het scherm verdwijnt
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }

    }
    //method als de speler wordt geraakt door een blok dat de speler object vernietigd wordt
    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy (gameObject);
        }
    }
}
