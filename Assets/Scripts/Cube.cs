using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape
{
    override protected float GetVolume()
    {
        float volume = Mathf.Pow(transform.localScale.x, 3);

        return volume;
    }

}
