using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance { get; private set; }
    public AnimationCurve shakeCurve;

    private CinemachineVirtualCamera cam;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float time, float force)
    {
        StartCoroutine(ScreenShakeCoroutine(time, force));
    }

    private IEnumerator ScreenShakeCoroutine(float time, float force)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float strenght = shakeCurve.Evaluate(elapsedTime / time);
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = strenght * force;

            yield return null;
        }
    }
}
