using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerTip : MonoBehaviour
{
    public FingerTipData data;
    
    [SerializeField] private int positionsMemoryLimit = 10;
    [SerializeField] private float positionsFrequencyCheck = 0.1f;

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
        for (;;)
        {
            _positionsQueue.Enqueue(transform.position);
            yield return new WaitForSeconds(positionsFrequencyCheck);
        }
    }
}

public class LimitedPositionsQueue : Queue<Vector3>
{
    private int Limit { get; }

    public LimitedPositionsQueue(int limit) : base(limit)
    {
        Limit = limit;
    }

    public new void Enqueue(Vector3 position)
    {
        while (Count >= Limit)
        {
            Dequeue();
        }
        base.Enqueue(position);
    }
    
    public float CalculateSumDistance()
    {
        float sumDistance = 0f;
        Vector3[] positionsArray = this.ToArray();

        for (int i = 0; i < Limit - 1; i++)
        {
            sumDistance += Vector3.Distance(positionsArray[i], positionsArray[i + 1]);
        }

        return sumDistance;
    }
}
