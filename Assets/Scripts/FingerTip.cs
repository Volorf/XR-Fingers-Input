using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Volorf.VRNotifications;

[Serializable]
public class LetterEvent: UnityEvent<string> {};

public class FingerTip : MonoBehaviour
{

    public TextMeshPro label;
    public FingerTipData data;
    public KeysPanelController keysPanelController;

    public LetterEvent letterEvent = new LetterEvent();
    
    [SerializeField] private int positionsMemoryLimit = 10;
    [SerializeField] private float positionsFrequencyCheck = 0.2f;

    [SerializeField] private Material normMat;
    [SerializeField] private Material activeMat;
 
    private LimitedPositionsQueue _positionsQueue;

    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private MeshRenderer meshRenderer;

    private bool _canInteract = true;
    private bool _canDehighlight = false;

    public void SetColliderTriggerOn()
    {
        sphereCollider.isTrigger = true;
        meshRenderer.material = activeMat;
    }
    
    public void SetColliderTriggerOff()
    {
        sphereCollider.isTrigger = false;
        meshRenderer.material = normMat;
    }
    
    public float GetSumDistance()
    {
        return _positionsQueue.CalculateSumDistance();
    }

    private void Start()
    {
        // _sphereCollider = GetComponent<SphereCollider>();
        // _meshRenderer = GetComponent<MeshRenderer>();
        _positionsQueue = new LimitedPositionsQueue(positionsMemoryLimit);
        StartCoroutine(PositionsCollector());
        keysPanelController.InitKeys(data.pairs);
    }

    private void OnTriggerEnter(Collider other)
    {
        _canDehighlight = false;
        
        if (other.gameObject.CompareTag("FingerTip") && _canInteract)
        {
            _canInteract = false;
            
            FingerTip otherFingerTip = other.gameObject.GetComponent<FingerTip>();
            if (GetSumDistance() < otherFingerTip.GetSumDistance())
            {
                if (data.Values.ContainsKey(otherFingerTip.data.type))
                {
                    string str = data.Values[otherFingerTip.data.type].ToString();
                    letterEvent.Invoke(str);
                    // Notification not = new Notification(str, NotificationType.Warning);
                    keysPanelController.HighlightKeys(otherFingerTip.data.type);
                    _canDehighlight = true;
                    // NotificationManager.Instance.AddMessage(not);
                }
            }
            // if (GetSumDistance() > otherFingerTip.GetSumDistance())
            // {
            //     if (otherFingerTip.data.Values.ContainsKey(data.type))
            //     {
            //         string str = "Value for " + otherFingerTip.data.type.ToString() + " is " + otherFingerTip.data.Values[data.type];
            //         Notification not = new Notification(str, NotificationType.Warning);
            //         NotificationManager.Instance.AddMessage(not);
            //     }
            // }
            // else
            // {
            //     if (data.Values.ContainsKey(otherFingerTip.data.type))
            //     {
            //         string str = "Value for " + data.type.ToString() + " is " + data.Values[otherFingerTip.data.type];
            //         Notification not = new Notification(str, NotificationType.Warning);
            //         NotificationManager.Instance.AddMessage(not);
            //     }
            // }

            StartCoroutine(MakeItInteractableAgain());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_canDehighlight) keysPanelController.DehighlightKeys();
    }

    private IEnumerator MakeItInteractableAgain()
    {
        float timer = 0f;

        while (timer < 1f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        _canInteract = true;
    }

    private IEnumerator PositionsCollector()
    {
        while(true)
        {
            // print("it works");
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
        return Mathf.Round(sumDistance * 1000f) / 1000f;
    }
}
