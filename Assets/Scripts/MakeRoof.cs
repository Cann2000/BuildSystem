using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRoof : MonoBehaviour
{
    [SerializeField] GameObject Roof;
    [SerializeField] GameObject Roofpreview;

    Transform Socket;

    public Color buildcolor;
    public Color nobuildcolor;

    bool CanBuild;


    void Update()
    {
        makeRoof();
    }

    void makeRoof()
    {
        if (CanBuild)
        {
            Roofpreview.GetComponent<Renderer>().material.SetColor("_Color", buildcolor);
        }
        if (!CanBuild)
        {
            Roofpreview.GetComponent<Renderer>().material.SetColor("_Color", nobuildcolor);
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (hit.transform.CompareTag("RoofSocket"))
            {
                CanBuild = true;
                Roofpreview.SetActive(true);
                Socket = hit.transform;
                Roofpreview.transform.position = Socket.position;

                if (Input.GetKeyDown(KeyCode.Mouse0) && CanBuild)
                {
                    GameObject RoofSpawn = Instantiate(Roof, Socket.transform.position, Quaternion.identity);
                    Destroy(Socket.gameObject);
                    Roofpreview.SetActive(false);
                    CanBuild = false;
                }
            }
            else
            {
                Roofpreview.SetActive(false);
                CanBuild = false;
            }
        }
    }
}
