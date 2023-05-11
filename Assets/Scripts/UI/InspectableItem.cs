using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InspectableItem : MonoBehaviour
{
    public ItemInfo Info;

    public void StartInspect()
    {
        InspectBubble bubble = Instantiate(
                                Info.InspectBubble, 
                                new Vector3(transform.position.x, transform.position.y, transform.position.z), 
                                Quaternion.identity
                               ).GetComponent<InspectBubble>();
        bubble.Initialize(Info);
    }
}
