using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSkript : MonoBehaviour
{
    [Header("Атлеты")]
    [SerializeField] private Transform[] Runner;

    private int i = 0;

    [Header("Палка")]
    [SerializeField] private GameObject stick;

    [Header("Скорость")]
    private int _speed = 9;

    void Update()
    {
        Running();
    }
    /// <summary>
    /// Бег
    /// </summary>
    private void Running()
    {
        if (i < Runner.Length - 1)
        {
            Runner[i].position = Vector3.MoveTowards(Runner[i].position, Runner[i + 1].position, _speed * Time.deltaTime);
            if (Runner[i].position == Runner[i + 1].position)
            {
                Runner[i].transform.LookAt(Runner[i + 1].position);
                stick.transform.LookAt(Runner[i + 1].position);

                stick.transform.SetParent(Runner[i + 1], true);

                i++;
            }
        }
        else
        {
            Runner[i].position = Vector3.MoveTowards(Runner[i].position, Runner[0].position, _speed * Time.deltaTime);
            if (Runner[i].position == Runner[0].position)
            {
                stick.transform.SetParent(Runner[0], true);

                i = 0;
            }
        }
    }
}
