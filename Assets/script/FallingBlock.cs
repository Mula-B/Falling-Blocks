using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    //snelheid van het block
    public Vector2 speedMinMax;
    float speed;

    float visibleHeightThreshold;

    void Start()
    {
        //hiermee kan je aangeven hoe snel je de blokken wilt laten vallen 
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        //bepaalt de positie wanneer het blok zichzelf vernietigd
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }
    

	 // Update is called once per frame
	void Update () {
        //zorgt dat het block naar beneden valt
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        //hiermee wordt een blok vernietigd als het ontweken is door de speler
        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
		
	}
}
