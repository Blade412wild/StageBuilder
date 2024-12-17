using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouwScript : MonoBehaviour
{
    public UnityEvent events = new();
    public GameObject rope;
    // Start is called before the first frame update
    void Start()
    {
        rope = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == rope)
            {
                events.Invoke();
            }
        }
    }
}
