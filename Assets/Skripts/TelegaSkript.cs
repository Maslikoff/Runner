using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelegaSkript : MonoBehaviour
{
    [Header("От начальной точки к конечной")]
    [SerializeField] private bool Forward;

    [Header("Массив векторов для движения телеги")]
    [SerializeField] private Vector3[] targetPoints;

    private float _speed = 5;
    private int _numbPoint;

    void Update()
    {
        ForwardMovement();
    }

    private void ForwardMovement()
    {
        var currentPosition = transform.position;
        var targetPosition = targetPoints[_numbPoint];
        var deltaDistance = Time.deltaTime * _speed;
        var distance = Vector3.Distance(currentPosition, targetPosition);
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, deltaDistance);
        if (distance <= 0.01f)
        {
            if (_numbPoint == 0)
                Forward = true;
            if (_numbPoint == targetPoints.Length - 1)
                Forward = false;

            if (Forward)
            {
                _numbPoint += 1;
                transform.LookAt(targetPoints[1]);
                //transform.Rotate(0, 180, 0);
            }
            else
            {
                _numbPoint -= 1;
                transform.LookAt(targetPoints[0]);
                //transform.Rotate(0, 180, 0);
            }
        }
    }
}
