using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _delay;

    private int _count;
    private bool _isWork;
    private WaitForSecondsRealtime _wait;

    private void OnValidate()
    {
        _wait = new WaitForSecondsRealtime(_delay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(_isWork = !_isWork)
                StartCoroutine(Run);
            else
                StopCoroutine(Run);
        }            
    }

    private IEnumerator Run
    {
        get
        {
            while (_isWork)
            {             
                yield return _wait;

                if (_isWork == false)
                    yield break;

                _count++;
                _text.text = _count.ToString();
            }            
        }
    }    
}