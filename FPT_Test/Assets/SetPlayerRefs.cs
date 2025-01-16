using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerRefs : MonoBehaviour
{
    [SerializeField] private PlayerRefs playerRefs;

    // Start is called before the first frame update
    void Start()
    {
        playerRefs.HeadTracking = GetComponentInChildren<HeadTracking>();
        playerRefs.Canvas = GetComponentInChildren<Canvas>();
        
        playerRefs.Canvas.gameObject.SetActive(false);  

        Debug.Log(playerRefs.HeadTracking);
        Debug.Log(playerRefs.Canvas);
    }
}
