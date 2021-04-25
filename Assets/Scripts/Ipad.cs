using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ipad : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private RectTransform _rawImage;
    [SerializeField] private GameObject _buttonHome;

    [SerializeField] private Camera _targetCamera;
    
    private Animator _animator;
    private bool _iPadOnScreen = true;
    private bool _swaped = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
   
    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && !_iPadOnScreen)
        {
            _iPadOnScreen = true;
            
            _animator.Play("BackToScreen");

            StartCoroutine(LateCall());
        }

        if (Input.GetKey(KeyCode.Q) && _iPadOnScreen && !_swaped)
        {
            _animator.Play("SwapOnQ");
            _rawImage.sizeDelta = new Vector2(444,306);
            _rawImage.localPosition = new Vector2(-630, -250);
            
            _canvas.SetActive(false);
            _buttonHome.SetActive(false);

            _targetCamera.fieldOfView = 90;

            _swaped = true;

            StartCoroutine(LateCall());
        }
        if (Input.GetKey(KeyCode.E) && _iPadOnScreen && _swaped)
        {
            _animator.Play("SwapOnE");
            _rawImage.sizeDelta = new Vector2(310, 445);
            _rawImage.localPosition = new Vector2(-616, -209.7f);
            
            _canvas.SetActive(false);
            _buttonHome.SetActive(true);

            _targetCamera.fieldOfView = 70;

            _swaped = false;

            StartCoroutine(LateCall());
        }
    }
    public void OnHomeButtonClick()
    {
        _iPadOnScreen = false;
        _canvas.SetActive(false);
       
        _animator.Play("HomeButton");
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1);

        _canvas.SetActive(true);
    }
}
