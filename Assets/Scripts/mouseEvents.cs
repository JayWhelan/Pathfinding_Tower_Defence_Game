using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseEvents : MonoBehaviour
{

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = new Ray(
                mainCamera.ScreenToWorldPoint(Input.mousePosition),
                mainCamera.transform.forward);
            // or:
            //_ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 5000f))
            {
                Debug.Log("Click2");
                if (hit.transform.tag == "turretholder")
                {
                   Debug.Log("Click3");
                }
            }
        }
    }
}
