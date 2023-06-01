using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public EventReference HibbidiHibbidi;

    public void PlaySound()
    {
        AudioManager.Instance.PlayOneShot(HibbidiHibbidi, Vector3.zero);
    }
}
