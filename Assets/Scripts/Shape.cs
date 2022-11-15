using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

abstract public class Shape : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI volumeText;
    [SerializeField]
    GameObject prefabToGenerate;

    bool alreadyCalledTheEvent = false;
    Vector3 vectorToMove;

    const float verticalBound = 16;
    const float topBound = 6;
    const float bottomBound = -3;
    const float speed = 2;

    abstract protected float GetVolume();

    void Start()
    {
        GenerateVectorToMove();

        volumeText.text = Math.Round(GetVolume(), 2).ToString();
    }

    void Update()
    {
        Vector3 vectorToMoveDeltaTime = vectorToMove * speed * Time.deltaTime;

        transform.Translate(vectorToMoveDeltaTime);

        if (
            transform.position.x >= verticalBound ||
            transform.position.x <= -verticalBound ||
            transform.position.y >= topBound ||
            transform.position.y <= bottomBound
        )
        {
            transform.Translate(-vectorToMoveDeltaTime);
            GenerateVectorToMove();
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!alreadyCalledTheEvent)
            {
                Destroy(gameObject);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!alreadyCalledTheEvent)
            {
                GameObject newShape = Instantiate(prefabToGenerate, transform.position, prefabToGenerate.transform.rotation);
                float newShapeScale = UnityEngine.Random.Range(0.5f, 2);
                newShape.transform.localScale = new Vector3(newShapeScale, newShapeScale, newShapeScale);
            }
        }

        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            alreadyCalledTheEvent = false;
        }
    }

    void GenerateVectorToMove()
    {
        vectorToMove = UnityEngine.Random.Range(0, 2) == 0 ? Vector3.up : Vector3.right;
        vectorToMove = UnityEngine.Random.Range(0, 2) == 0 ? vectorToMove : -vectorToMove;
    }

}
