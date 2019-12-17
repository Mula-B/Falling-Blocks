using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    //het object block
    public GameObject fallingBlockPrefab;
    //wanneer de blokken spawnen
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    //grote van een blok
    public Vector2 spawnSizeMinMax;
    //float voor dat de blokken ook een schuine richting hebben
    public float spawnAngleMax;
    //berekenen van de grote van het scherm waar de blokken worden gespawnt 
    Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start () {
        //berekening grote van het scherm waar de blokken spawnen
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
        //wanneer de blokken spawnen
        if (Time.time > nextSpawnTime)
        {
            //moeilijkheids graat wordt berekent
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            //spawn is staat nu vast
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            //positie van de veschillende grote blok
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            //waar de blokken spawnen
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            //hier worden de verschillende grote van de blokken gespawnt
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
	}
}
