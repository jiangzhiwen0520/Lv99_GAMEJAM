using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Camera1 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cvCamera;
    [SerializeField] private float nervous;

    private CinemachineBasicMultiChannelPerlin noise;
    private bool isStarted = false;
    private float elapsedTime = 0.0f;

    private float preNervous;
    void Start()
    {
        noise = cvCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        //cvCamera.m_Lens.OrthographicSize = 3f;
        noise.m_AmplitudeGain = 0f;
        nervous = 0.0f;
    }


    void Update()
    {
        /*if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            isStarted = true;
        }
        if (isStarted)
        {
            preNervous = nervous;
            elapsedTime += Time.deltaTime;
            nervous =GameObject.Find("PressureController").GetComponent<PreesureController>().GetPressurePoint();
        }

        float disNervous = nervous - preNervous;*/
        nervous = GameObject.Find("PressureController").GetComponent<PreesureController>().GetPressurePoint();
        //cvCamera.m_Lens.OrthographicSize -= 0.02f * disNervous;
        //Debug.Log(cvCamera.m_Lens.OrthographicSize);
        if (nervous >= 50.0)
        {
            noise.m_AmplitudeGain = (nervous-50f)/50f;
        }
        else
        {
            noise.m_AmplitudeGain = 0f;
        }

        if (cvCamera.m_Lens.OrthographicSize <= 2f)
        {
            cvCamera.m_Lens.OrthographicSize = 2f;
        }
    }
}
