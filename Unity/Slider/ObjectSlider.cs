using UnityEngine;
using UnityEngine.UI;

public class ObjectSlider : MonoBehaviour
{
    [SerializeField] private Slider _objectSlider;
    [SerializeField] private Button _resetButton;
    [SerializeField] private GameObject _targetObject;

    void Start()
    {
        if (_objectSlider != null)
        {
            _objectSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    public void OnSliderValueChanged(float value)
    {
        if (_targetObject != null)
        {
            _targetObject.transform.localScale = new Vector3(value, value, value);
        }
    }

    public void ResetTargetObject()
    {
        if (_targetObject != null)
        {
            _targetObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
