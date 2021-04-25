using UnityEngine;
using UnityEngine.UI;

public class SpinCrane : MonoBehaviour
{
    [Header("Controll Spin")]
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _minClamp = 0f;
    [SerializeField] private float _maxClamp = 720f;

    [Header("View Of Power")]
    [SerializeField] private Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    [Header("Type of Particles")]
    [SerializeField] private ParticleSystem _particles;

    
    private float _yRotation = 0.0f;

    private float time = 0f;

    private bool _greenTubeOpen = false;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * _rotationSpeed;

        // float rotY = Input.GetAxis("Mouse Y") * _rotationSpeed;

        // transform.Rotate(Vector3.down, rotX);
        
        _yRotation = Mathf.Clamp(_yRotation - Input.GetAxis("Mouse X") * _rotationSpeed, _minClamp, _maxClamp);
        transform.eulerAngles = new Vector3(0.0f, _yRotation, 0.0f);
    }

    private void FixedUpdate()
    {
        if (_yRotation > 0)
        {
            _particles.Play();
            PowerWater(_yRotation);

            _greenTubeOpen = true;
        }
        else
        {
            _particles.Stop();
        }
    }
    private void Update()
    {
        if (_greenTubeOpen)
        {
            time += Time.deltaTime;
            _slider.value = _yRotation;
            _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        }
    }

    private float PowerWater(float power)
    {
        return _particles.startSize = power/300;
    }


}
