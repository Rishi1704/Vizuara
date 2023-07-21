using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    [SerializeField] private AudioSource correct;
    [SerializeField] private AudioSource incorrect;
    [SerializeField] private GameObject camController;
    [SerializeField] private GameObject EndScrene;
    [SerializeField] private GameObject[] magneticObj;
    [SerializeField] private GameObject[] nonMagneticObj;
    [SerializeField] private Vector3[] magneticDestination;
    [SerializeField] private Vector3[] nonMagneticDestination;
    [SerializeField] private int noOfMagneticObjects;
    [SerializeField] private int noOfNonMagneticObjects;

    private GameObject selectedObject;
    private Vector3 initialPos;
    private int magneticObjects = 0;
    private int nonMagneticObjects = 0;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)
                {
                    if(!hit.collider.CompareTag("Drag"))
                        return;
                    
                    click.Play();
                    selectedObject = hit.collider.gameObject;
                    initialPos = selectedObject.transform.position;
                    camController.SetActive(false);
                }
            }
        }

        if(selectedObject != null)
        {
            if(Input.GetMouseButton(0))
            {
                Renderer renderer = selectedObject.GetComponent<Renderer>();

                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, 2.5f, worldPosition.z);
            }
            else
            {
                RaycastHit hit;
                if(Physics.Raycast(selectedObject.transform.position, Vector3.down, out hit))
                {
                    if(hit.collider.gameObject.tag == selectedObject.transform.parent.gameObject.tag)
                    {
                        correct.Play();
                        float height = selectedObject.transform.position.y - selectedObject.GetComponent<Collider>().bounds.min.y;
                        if(selectedObject.transform.parent.gameObject.tag == "Magnetic")
                        {
                            selectedObject.transform.position = magneticDestination[GetIndex()];
                            magneticObjects++;
                        }
                        else
                        {
                            selectedObject.transform.position = nonMagneticDestination[GetIndex()];
                            nonMagneticObjects++;
                        }
                        
                        selectedObject.transform.position = new Vector3(
                            selectedObject.transform.position.x, 
                            2f + height, 
                            selectedObject.transform.position.z);
                        
                        selectedObject.tag = "Untagged";
                    }
                    
                    else
                    {
                        incorrect.Play();
                        selectedObject.transform.position = initialPos;
                    }
                }
                
                if(hit.collider == null)
                {
                    incorrect.Play();
                    selectedObject.transform.position = initialPos;
                }

                selectedObject = null;
                camController.SetActive(true);

                if(magneticObjects == noOfMagneticObjects && nonMagneticObjects == noOfNonMagneticObjects)
                {
                    EndScrene.SetActive(true);
                }
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosnear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;

        Physics.Raycast(worldMousePosnear, worldMousePosFar - worldMousePosnear, out hit);

        return hit;
    }

    private int GetIndex()
    {
        if(selectedObject.transform.parent.gameObject.tag == "Magnetic")
        {
            for (int i = 0; i < noOfMagneticObjects; i++)
            {
                if(selectedObject == magneticObj[i])
                    return i;
            }
        }
        else
        {
            for (int i = 0; i < noOfNonMagneticObjects; i++)
            {
                if(selectedObject == nonMagneticObj[i])
                    return i;
            }
        }

        return -1;
    }
}
