using UnityEngine;
using System.Collections;

public class DynamicTile : MonoBehaviour {
    public string heroLayerName = "Hero";
    private int initSortingOrder = 0;
    private GameObject player;
    private SpriteRenderer sr;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        sr.sortingLayerName = heroLayerName;
        initSortingOrder = sr.sortingOrder;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y + 0.1f >= transform.position.y)
            sr.sortingOrder = initSortingOrder + 1;
        else
            sr.sortingOrder = initSortingOrder - 1;
    }
}
