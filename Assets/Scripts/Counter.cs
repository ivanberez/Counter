using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _delay;

    private int _count;
    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;    

    private void OnValidate()
    {
        _wait = new WaitForSecondsRealtime(_delay);        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }                
            else
            {
                _coroutine = StartCoroutine(Run());
            }                
        }
    }

    private IEnumerator Run()
    {
        while (enabled)
        {
            yield return _wait;

            _count++;
            _text.text = _count.ToString();
        }
    }
}