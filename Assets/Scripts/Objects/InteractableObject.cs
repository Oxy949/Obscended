using UnityEngine;
using System.Collections;
using System;

public class InteractableObject : MonoBehaviour {

    public delegate void ObjectNearEventHandler(object sender, EventArgs e);
    public event ObjectNearEventHandler ObjectNear;

    public delegate void InteractionStartedEventHandler(object sender, EventArgs e);
    public event InteractionStartedEventHandler InteractionStarted;

    public delegate void InteractionFinishedEventHandler(object sender, EventArgs e);
    public event InteractionFinishedEventHandler InteractionFinished;

    public float radius = 1;
    public float interactionTime = 0.1f;
    public bool useFacingDirection = true;
    GameObject player;
    //bool isInteracting = false;
    // Use this for initialization
    public virtual void Start () {
        player = FindClosestPlayer();
    }

    // Update is called once per frame
    public virtual void Update () {
        player = FindClosestPlayer();
        PlayerController pc = player.GetComponent<PlayerController>();

        if (Distance2D(player.transform.position - transform.position) <= radius)
            OnObjectNear();

        if (pc.isInteractingNow() && pc.interactionObj == gameObject && !pc.interactionObjFounded)
        {
            OnInteractionStarted();
            pc.interactionObjFounded = true;
        }
    }

    protected virtual void OnObjectNear()
    {
        if (ObjectNear != null)
            ObjectNear(this, null);
        //Debug.Log("[InteractableObject] Can interact with " + transform.name);
    }

    protected virtual void OnInteractionStarted()
    {
        if (InteractionStarted != null)
            InteractionStarted(this, null);
        //Debug.Log("[InteractableObject] Interacting with " + transform.name);
    }

    public virtual void OnInteractionFinished()
    {
        if (InteractionFinished != null)
            InteractionFinished(this, null);
        //Debug.Log("[InteractableObject] Interacting finished " + transform.name);
    }

    float Distance2D(Vector3 vec)
    {
        return Mathf.Sqrt(
          Mathf.Pow(vec.x, 2f) +
          Mathf.Pow(vec.y, 2f) +
          Mathf.Pow(0, 2f));
    }

    GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = new Vector3(go.transform.position.x - position.x, go.transform.position.y - position.y, 0);
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
