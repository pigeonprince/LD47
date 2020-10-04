using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoomDetector : MonoBehaviour
{
    public bool hiddenRoomDetector = false;
    public Collider2D colliderCircle;
    public ParticleSystem vfx;
    void Start()
    {
        colliderCircle.enabled = !colliderCircle.enabled;
    }

    void Update()
    {
        if (hiddenRoomDetector)
        {
        DetectHiddenRoom();
        }
    }

    private void DetectHiddenRoom()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            colliderCircle.enabled = !colliderCircle.enabled;
            ParticleSystem visualEffects = Instantiate(vfx, gameObject.transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(visualEffects, 0.3f);
        }
        else if(Input.GetKeyUp(KeyCode.X))
        {
            colliderCircle.enabled = !colliderCircle.enabled;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("HiddenWall"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
