using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    override protected float GetVolume()
    {
        float radius = transform.localScale.x / 2;
        float volume = 4 / 3 * 3.14f * Mathf.Pow(radius, 3);

        return volume;
    }
}
