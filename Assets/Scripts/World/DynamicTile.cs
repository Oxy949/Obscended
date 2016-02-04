using UnityEngine;
using System.Collections;

public class DynamicTile : MonoBehaviour {
    public float aboveZ = -6;
    public float belowZ = 0;
    private GameObject player;
    private float initZ = 0;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        initZ = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y+0.1f >= transform.position.y)
            transform.position = new Vector3(transform.position.x, transform.position.y, initZ + aboveZ);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, initZ + belowZ);
    }
}
