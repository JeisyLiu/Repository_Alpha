using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerListener : EventTrigger
{
    #region 变量
    public delegate void VoidDelegate();
    public delegate void PointerEventDelegate(PointerEventData eventData);
    public delegate void BaseEventDelegate(BaseEventData eventData);
    public delegate void AxisEventDelegate(AxisEventData eventData);

    //不带参
    public event VoidDelegate onPointerEnter;
    public event VoidDelegate onPointerExit;
    public event VoidDelegate onPointerDown;
    public event VoidDelegate onPointerUp;
    public event VoidDelegate onPointerClick;
    public event VoidDelegate onInitializePotentialDrag;
    public event VoidDelegate onBeginDrag;
    public event VoidDelegate onDrag;
    public event VoidDelegate onEndDrag;
    public event VoidDelegate onDrop;
    public event VoidDelegate onScroll;
    public event VoidDelegate onUpdateSelected;
    public event VoidDelegate onSelect;
    public event VoidDelegate onDeselect;
    public event VoidDelegate onMove;
    public event VoidDelegate onSubmit;
    public event VoidDelegate onCancel;

    //带参
    public event PointerEventDelegate onPointerEnterPara;
    public event PointerEventDelegate onPointerExitPara;
    public event PointerEventDelegate onPointerDownPara;
    public event PointerEventDelegate onPointerUpPara;
    public event PointerEventDelegate onPointerClickPara;
    public event PointerEventDelegate onInitializePotentialDragPara;
    public event PointerEventDelegate onBeginDragPara;
    public event PointerEventDelegate onDragPara;
    public event PointerEventDelegate onEndDragPara;
    public event PointerEventDelegate onDropPara;
    public event PointerEventDelegate onScrollPara;
    public event BaseEventDelegate onUpdateSelectedPara;
    public event BaseEventDelegate onSelectPara;
    public event BaseEventDelegate onDeselectPara;
    public event AxisEventDelegate onMovePara;
    public event BaseEventDelegate onSubmitPara;
    public event BaseEventDelegate onCancelPara;
    #endregion

    public static EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null)
        {
            listener = go.AddComponent<EventTriggerListener>();
        }
        return listener;
    }

    public static void Remove(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener != null)
        {
            Destroy(listener);
        }
    }

    #region 方法
    public override void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.LogWarning("OnPointerEnter");

        if (onPointerEnter != null)
        {
            onPointerEnter();
        }

        if (onPointerEnterPara != null)
        {
            onPointerEnterPara(eventData);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        //Debug.LogWarning("OnPointerExit");

        if (onPointerExit != null)
        {
            onPointerExit();
        }

        if (onPointerExitPara != null)
        {
            onPointerExitPara(eventData);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //Debug.LogWarning("OnPointerDown");

        if (onPointerDown != null)
        {
            onPointerDown();
        }

        if (onPointerDownPara != null)
        {
            onPointerDownPara(eventData);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //Debug.LogWarning("OnPointerUp");

        if (onPointerUp != null)
        {
            onPointerUp();
        }

        if (onPointerUpPara != null)
        {
            onPointerUpPara(eventData);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        //Debug.LogWarning("OnPointerClick");

        if (onPointerClick != null)
        {
            onPointerClick();
        }

        if (onPointerClickPara != null)
        {
            onPointerClickPara(eventData);
        }
    }

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        //Debug.LogWarning("OnInitializePotentialDrag");

        if (onInitializePotentialDrag != null)
        {
            onInitializePotentialDrag();
        }

        if (onInitializePotentialDragPara != null)
        {
            onInitializePotentialDragPara(eventData);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.LogWarning("OnBeginDrag");

        if (onBeginDrag != null)
        {
            onBeginDrag();
        }

        if (onBeginDragPara != null)
        {
            onBeginDragPara(eventData);
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        //Debug.LogWarning("OnDrag");

        if (onDrag != null)
        {
            onDrag();
        }

        if (onDragPara != null)
        {
            onDragPara(eventData);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        //Debug.LogWarning("OnEndDrag");

        if (onEndDrag != null)
        {
            onEndDrag();
        }

        if (onEndDragPara != null)
        {
            onEndDragPara(eventData);
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        //Debug.LogWarning("OnDrop");

        if (onDrop != null)
        {
            onDrop();
        }

        if (onDropPara != null)
        {
            onDropPara(eventData);
        }
    }

    public override void OnScroll(PointerEventData eventData)
    {
        //Debug.LogWarning("OnScroll");

        if (onScroll != null)
        {
            onScroll();
        }

        if (onScrollPara != null)
        {
            onScrollPara(eventData);
        }
    }

    public override void OnUpdateSelected(BaseEventData eventData)
    {
        //Debug.LogWarning("OnUpdateSelected");

        if (onUpdateSelected != null)
        {
            onUpdateSelected();
        }

        if (onUpdateSelectedPara != null)
        {
            onUpdateSelectedPara(eventData);
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        //Debug.LogWarning("OnSelect");

        if (onSelect != null)
        {
            onSelect();
        }

        if (onSelectPara != null)
        {
            onSelectPara(eventData);
        }
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        //Debug.LogWarning("OnDeselect");

        if (onDeselect != null)
        {
            onDeselect();
        }

        if (onDeselectPara != null)
        {
            onDeselectPara(eventData);
        }
    }

    public override void OnMove(AxisEventData eventData)
    {
        //Debug.LogWarning("OnMove");

        if (onMove != null)
        {
            onMove();
        }

        if (onMovePara != null)
        {
            onMovePara(eventData);
        }
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        //Debug.LogWarning("OnSubmit");

        if (onSubmit != null)
        {
            onSubmit();
        }

        if (onSubmitPara != null)
        {
            onSubmitPara(eventData);
        }
    }

    public override void OnCancel(BaseEventData eventData)
    {
        //Debug.LogWarning("OnCancel");

        if (onCancel != null)
        {
            onCancel();
        }

        if (onCancelPara != null)
        {
            onCancelPara(eventData);
        }
    }
    #endregion
}