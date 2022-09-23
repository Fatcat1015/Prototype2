using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    float lerpDuration = 10;
    public GameObject[] Coords;
    public int CurrentCoords = 0;
    float tpassed = 0;

    public GameObject gm;
    public GameObject Gucci;

    public bool instore = false;

    private void Start()
    {
        StartLerp();
    }

    void Update()
    {

        Gucci.transform.position = new Vector3(transform.position.x, transform.position.y,0);

        if (!instore )
        {
            if (!gm.GetComponent<GameManagerCode>().dialogueShowing)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    MoveCamLeft();
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    MoveCamRight();
                }
            }
            

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveCamAction();
                
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                //buy item selected
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //select left
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            { 
                //select right
            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //go to Gucci fashion show
            //need some kind of numeric goal
            
        }
    }

    void FixedUpdate()
    { 
        if (tpassed < lerpDuration)
        {
            float t = tpassed / lerpDuration;
            t = t * t * (3f - 2f * t);
            transform.position = Vector3.Lerp(transform.position, Coords[CurrentCoords].transform.position, t);
            tpassed += 1;
        }
        else
        {
            transform.position = Coords[CurrentCoords].transform.position;
        }
    }

    private void StartLerp()
    {
        tpassed = 0;
    }

    void MoveCamLeft()
    {
        if(CurrentCoords != 0)CurrentCoords = CurrentCoords - 1;
        else
        {
            CurrentCoords = Coords.Length - 1;
        }
        StartLerp();
    }

    void MoveCamRight()
    {
        if (CurrentCoords != Coords.Length-1) CurrentCoords = CurrentCoords + 1;
        else
        {
            CurrentCoords = 0;
        }
        StartLerp();
    }

    void MoveCamAction()
    {
        gm.GetComponent<GameManagerCode>().Action(CurrentCoords);
    }
}
