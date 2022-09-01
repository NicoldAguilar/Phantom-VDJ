using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; //espacio a dejar de un punto a otro punto

    [Range(1,10)]
    public float smootherFactor; //realiza el efecto de camara

    void Start()
    {

    }

    void Update()
    {       
        var targetPosition = target.position + offset; //el transform de la camara va a ser igual al trasform del player 
        var smootherPosition = Vector3.Lerp(transform.position, targetPosition, smootherFactor * Time.fixedDeltaTime); //
        transform.position = smootherPosition;
    }
}
