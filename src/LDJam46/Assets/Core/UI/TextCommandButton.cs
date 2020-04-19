using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class TextCommandButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private GameObject selector;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    public TextCommandButton Initialized(NamedCommand cmd)
    {
        Init(cmd);
        return this;
    }
    
    public void Init(NamedCommand cmd)
    {
        label.text = cmd.Name;
        _button.onClick.AddListener(() => cmd.Action.Invoke());
    }

    public void Select()
    {
	    selector.SetActive(true);
        _button.Select();
    }

    public void Execute() => _button.onClick.Invoke();

    public void OnPointerEnter(PointerEventData eventData) => Select();
    public void OnSelect(BaseEventData eventData) => selector.SetActive(true);
    public void OnDeselect(BaseEventData eventData)
    {
	    selector.SetActive(false);
	    //_button.OnDeselect(eventData);
    }
}
