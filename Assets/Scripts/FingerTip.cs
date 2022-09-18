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
        return 0f;
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
    
    // TODO: Write method to calculate sum distance
}
