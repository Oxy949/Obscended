using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {
    public float radius = 1;
    public float interactionTime = 2;
    public bool useFacingDirection = true;
    GameObject player;
    bool isInteracting = false;
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
            OnInteraction();
            pc.interactionObjFounded = true;
        }
    }

    public virtual void OnObjectNear()
    {
        Debug.Log("[InteractableObject] Can interact with " + transform.name);
    }

    public virtual void OnInteraction()
    {
        Debug.Log("[InteractableObject] Interacting with " + transform.name);
    }

    public virtual void OnInteractionFinished()
    {
        Debug.Log("[InteractableObject] Interacting finished " + transform.name);
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
