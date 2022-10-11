using UnityEngine;

public class FpsLocker : MonoBehaviour
{
    [SerializeField] private int maxFps;
    
    private void Awake()
    {
        Application.targetFrameRate = maxFps;
    }
}
