using UnityEngine;
using UnityEngine.EventSystems;

public class SetFirstObjCanvas : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject firstObj;

    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(firstObj);
    }
}
