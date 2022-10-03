using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFoundation : MonoBehaviour
{
    [SerializeField] GameObject Foundation;
    [SerializeField] GameObject Foundationpreview;

    Transform Socket;

    bool CanBuild;

    public Color buildcolor;
    public Color nobuildcolor;


    void Update()
    {
        makeFoundation();
    }

    void makeFoundation()
    {
        if (CanBuild)
        {
            Foundationpreview.GetComponent<Renderer>().material.SetColor("_Color", buildcolor);
        }
        if (!CanBuild)
        {
            Foundationpreview.GetComponent<Renderer>().material.SetColor("_Color", nobuildcolor);
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 15))
        {

            if (hit.transform.CompareTag("Foundation"))
            {
                CanBuild = false;
                Foundationpreview.SetActive(false);
            }

            if (hit.transform.CompareTag("Place"))
            {
                CanBuild = true;
                Foundationpreview.SetActive(true);
                Foundationpreview.transform.position = hit.point;

                if (Input.GetKeyDown(KeyCode.Mouse0) && CanBuild)
                {
                    GameObject FoundationSpawn = Instantiate(Foundation, Foundationpreview.transform.position, Quaternion.identity);
                    CanBuild = false;
                    Foundationpreview.SetActive(false);
                }
            }

            if (hit.transform.CompareTag("FoundationSocket"))
            {
                CanBuild = true;
                Foundationpreview.SetActive(true);
                Socket = hit.transform;
                Foundationpreview.transform.position = Socket.position;

                if (Input.GetKeyDown(KeyCode.Mouse0) && CanBuild)
                {
                    GameObject FoundationSpawn = Instantiate(Foundation, Socket.position, Quaternion.identity);
                    Destroy(Socket.gameObject);
                    CanBuild = false;
                    Foundationpreview.SetActive(false);
                }
            }
        }


    }
}
