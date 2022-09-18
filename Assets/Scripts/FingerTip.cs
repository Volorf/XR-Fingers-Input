using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FingerTip : MonoBehaviour
{
    public TextMeshPro label;
    public FingerTipData data;
    
    [SerializeField] private int positionsMemoryLimit = 10;
    [SerializeField] private float positionsFrequencyCheck = 0.2f;

    private LimitedPositionsQueue _positionsQueue;

    public float GetSumDistance()
    {
        return _positionsQueue.CalculateSumDistance();
    }

    private void Start()
    {
        _positionsQueue = new LimitedPositionsQueue(positionsMemoryLimit);
        StartCoroutine(PositionsCollector());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FingerTip"))
        {
            FingerTip otherFingerTip = other.gameObject.GetComponent<FingerTip>();
        }
    }

    private IEnumerator PositionsCollector()
    {
        while(true)
        {
            print("it works");
            _positionsQueue.Enqueue(transform.position);
            label.text = _positionsQueue.CalculateSumDistance().ToString();
            yield return new WaitForSeconds(positionsFrequencyCheck);
        }
    }
}

public class LimitedPositionsQueue
{
    private int Limit;

    private Queue<Vector3> _limQueue = new Queue<Vector3>();

    public LimitedPositionsQueue(int limit)
    {
        Limit = limit;
    }

    public void Enqueue(Vector3 position)
    {
        if (_limQueue.Count > Limit)
        {
            _limQueue.Dequeue();
        }
        _limQueue.Enqueue(position);
    }
    
    public float CalculateSumDistance()
    {
        float sumDistance = 0f;
        Vector3[] positionsArray = _limQueue.ToArray();

        if (positionsArray.Length <= 1)
        {
            return 0f;
        }

        for (int i = 0; i < positionsArray.Length - 1; i++)
        {
            sumDistance += Vector3.Distance(positionsArray[i], positionsArray[i + 1]);
        }
        return sumDistance;
    }
}
