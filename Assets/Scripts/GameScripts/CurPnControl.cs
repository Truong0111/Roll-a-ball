using UnityEngine;
using UnityEngine.EventSystems;
public class CurPnControl : MonoBehaviour, IPointerDownHandler
{
    public GameObject JoyStick;
    public Vector3 InputDirection { set; get; }
    GameUIManager m_ui;
    public void Start()
    {
        m_ui = FindObjectOfType<GameUIManager>();
        InputDirection = Vector3.zero;
        if (Application.platform != RuntimePlatform.Android)
        {
            m_ui.showJoyStickCont(false);
        }
        else m_ui.showJoyStickCont(true);
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        Vector2 Joypos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            ((RectTransform) this.transform,
            ped.position,
            ped.pressEventCamera,
            out Joypos))
        {
            float x = ped.position.x;
            float y = ped.position.y;
            JoyStick.transform.position = new Vector3(x, y);
        }
    }


    
}
