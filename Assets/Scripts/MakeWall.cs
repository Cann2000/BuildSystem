using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWall : MonoBehaviour
{
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject Wallpreview;

    Transform socket;

    public Color buildcolor;
    public Color nobuildcolor;

    bool CanBuild;


    void Update()
    {
        makeWall();
    }

    void makeWall()
    {
        if (CanBuild)
        {
            Wallpreview.GetComponent<Renderer>().material.SetColor("_Color", buildcolor);
        }
        if (!CanBuild)
        {
            Wallpreview.GetComponent<Renderer>().material.SetColor("_Color", nobuildcolor);
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (hit.transform.CompareTag("WallSocket"))
            {
                CanBuild = true;
                Wallpreview.SetActive(true);

                socket = hit.transform;
                Wallpreview.transform.position = socket.position;
                Wallpreview.transform.rotation = socket.rotation;

                if (Input.GetKeyDown(KeyCode.Mouse0) && CanBuild)
                {
                    GameObject WallSpawn = Instantiate(Wall, socket.transform.position, socket.transform.rotation);
                    Destroy(socket.gameObject);
                    CanBuild = false;
                    Wallpreview.SetActive(false);
                }
            }

            else
            {
                CanBuild = false;
                Wallpreview.SetActive(false);
            }
            
        }
    }
}
