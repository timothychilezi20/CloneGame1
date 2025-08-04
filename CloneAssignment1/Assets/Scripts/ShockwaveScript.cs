using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem; 

public class ShockwaveScript : MonoBehaviour
{
    [SerializeField] private float shockWaveTime = 0.75f;

    private Coroutine _shockwaveCoroutine;

    private Material _material;

    private static int _waveDistanceFromCenter = Shader.PropertyToID("_waveDistanceFromCenter");

    private void Awake()
    {
       _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            CallShockWave(); 
        }
    }
    public void CallShockWave()
    {
        _shockwaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f, 1f)); 
    }

    private IEnumerator ShockWaveAction(float startPos, float endPos)
    {
        _material.SetFloat(_waveDistanceFromCenter, startPos);

        float lerpedAmount = 0f;

        float elapsedTime = 0f; 
        while(elapsedTime < shockWaveTime)
        {
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / shockWaveTime));
            _material.SetFloat(_waveDistanceFromCenter, lerpedAmount);

            yield return null;
        }
    }
}
