using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageFXs : MonoBehaviour
{
    public static StageFXs Instance;

    [SerializeField] private float _delay;
    [SerializeField] private int[] _stepPoints;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private Image _countDown;
    [SerializeField] private Sprite _three;
    [SerializeField] private Sprite _two;
    [SerializeField] private Sprite _one;
    [SerializeField] private Sprite _go;

    [SerializeField] private Vector3 _startSize;

    private void OnEnable()
    {
        Instance = this;
    }

    public IEnumerator PlayStartFX()
    {
        yield return StartCountDown();
        //NetWorkManager.IsPlay = true;
        StartCoroutine(StepPlayFX());
        StartCoroutine(Shutdown());
    }

    private IEnumerator StepPlayFX()
    {
        if(_stepPoints == null || _stepPoints.Length <= 0)
        {
            for (int i = 0; i < _particles.Length; i++)
            {
                _particles[i].Play();
            }
        }

        else
        {
            int tempIdx = 0;
            WaitForSeconds wait = new WaitForSeconds(_delay);

            for (int i = 0; i < _particles.Length; i++)
            {
                _particles[i].Play();

                if (tempIdx <= _stepPoints.Length -1 && _stepPoints[tempIdx] == i)
                {
                    tempIdx++;
                    yield return wait;
                }
            }
        }
    }

    private IEnumerator StartCountDown()
    {
        _countDown.gameObject.SetActive(true);

        _countDown.sprite = _three;
        StartCoroutine(PunchImage());
        yield return new WaitForSeconds(1);
        _countDown.sprite = _two;
        StartCoroutine(PunchImage());
        yield return new WaitForSeconds(1);
        _countDown.sprite = _one;
        StartCoroutine(PunchImage());
        yield return new WaitForSeconds(1);
        _countDown.sprite = _go;
        StartCoroutine(PunchImage());
    }

    private IEnumerator Shutdown()
    {
        yield return new WaitForSeconds(1f);
        _countDown.gameObject.SetActive(false);
    }

    private IEnumerator PunchImage()
    {
        _countDown.transform.localScale = _startSize;

        float duration = 0.6f;
        float t = 0;
        float smooth;

        while (t < 1)
        {
            t += Time.deltaTime / duration;
            smooth = Mathf.SmoothStep(0, 1, t);

            _countDown.transform.localScale = Vector3.Lerp(_startSize, Vector3.one, smooth);

            yield return null;
        }

        _countDown.transform.localScale = Vector3.one;

    }

    private void OnDisable()
    {
        Instance = null;
    }
}