using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    bool isOpening = false;
    [SerializeField] bool shutters;
    [SerializeField] Transform newPosition;

    public GameObject emergencySound;

    void Start()
    {
        if (shutters == true)
        {
            if (emergencySound != null)
                SoundManager.Instance.PlaySound(this.transform, emergencySound);
            DoorOpen();
        }
    }

    void Update()
    {
        if (isOpening == true)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition.position, 1f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newPosition.rotation, 1f * Time.deltaTime);

            if (transform.position == newPosition.position && transform.rotation == newPosition.rotation)
            {
                isOpening = false;
            }
        }
        
    }
    public void DoorOpen()
    {
        isOpening = true;
    }
}
