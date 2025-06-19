using UnityEngine;
using UnityEngine.EventSystems;

public class UIRouter : MonoBehaviour
{
    public Canvas[] canvasScreens;
    public void SwitchCanvas(Canvas target)
    {
        foreach (var canvas in canvasScreens)
        {
            if (canvas == null) continue;
            canvas.gameObject.SetActive(canvas == target);
        }
    }

    public void SwitchWindow(GameObject target)
    {
        Transform tempParent = target.transform.parent;

        for (int i = 0; i < tempParent.childCount; i++)
        {
            tempParent.GetChild(i).gameObject.SetActive(false);
        }

        target.gameObject.SetActive(true);
    }
}
