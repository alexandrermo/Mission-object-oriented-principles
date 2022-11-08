using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    bool alreadyCalledTheEvent = false;

    void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            if (!alreadyCalledTheEvent)
            {
                Debug.Log(1);
                alreadyCalledTheEvent = true;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (!alreadyCalledTheEvent)
            {
                Debug.Log(0);
                alreadyCalledTheEvent = true;
            }
        }

        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            alreadyCalledTheEvent = false;
        }
    }

}
