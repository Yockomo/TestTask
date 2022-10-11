using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action OnCompliteAction;
    
    private int speed;
    private int distance;
    private Vector3 direction;

    private TweenerCore<Vector3, Vector3, VectorOptions> moveTween;

    private void OnDestroy()
    {
        OnCompliteAction = null;
        ClearTween();
    }
    
    public void SetParameters(int speed, int distance, Vector3 direction)
    {
        this.speed = speed;
        this.distance = distance;
        this.direction = direction;
        
        Configure();
    }

    public bool TryStart()
    {
        if (moveTween != null)
        {
            moveTween.Play();
        }

        return moveTween != null;
    }

    public void Stop()
    {
        ClearTween();
        Complete();
    }
    
    private void Configure()
    {
        ClearTween();
        
        var endValue = direction.normalized * distance;
        var time = distance / speed;
        moveTween = transform.DOMove(endValue, time);
        moveTween.onComplete += Complete;
    }

    private void Complete()
    {
        OnCompliteAction?.Invoke();
    }

    private void ClearTween()
    {
        if (moveTween != null)
        {
            moveTween.onComplete -= Complete;
            moveTween.Kill();   
        }
    }
}
