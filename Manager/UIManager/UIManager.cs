/***
 *       UI管理器  
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Camera UICamera = null;
    private static UIManager _Instance = null;
    //缓存所有UI窗体
    private Dictionary<string, BaseUIForm> mUIFormList;
    private List<string> mDownLoadingUI;
    //被其他UI Hide的窗体
    private List<BaseUIForm> mHideList;
    //UI根节点
    private Transform mUIRoot = null;
    private Transform mNormalRoot = null;
    private Transform mCenter = null;
    private Transform mTopRoot = null;
    private Transform mCoverRoot = null;
    public Transform UIEvent = null;
    public UIRoot UIRootScript = null;
    public bool CoverInput = false;
    public Action ClickBack = null;
    public Action DelOnSubmit = null;
    public Action DelOnCancel = null;
    private List<string> mUIInputStack;
    private Canvas uiCanvas = null;
    private GameObject gUITexture;
    public static UIManager Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = ManagerAssistant.UIManager;
            return _Instance;
        }
    }
    public Canvas UICanvas
    {
        get { return uiCanvas; }
    }
    void Awake()
    {
        mUIInputStack = new List<string>();
        mUIFormList = new Dictionary<string, BaseUIForm>();
        mHideList = new List<BaseUIForm>();
        mDownLoadingUI = new List<string>();
        mUIRoot = GameObject.Find("UIRoot").transform;
        UICamera = mUIRoot.transform.FindChild("UICamera").GetComponent<Camera>();
        uiCanvas = mUIRoot.GetComponent<Canvas>();
        mNormalRoot = mUIRoot.transform.FindChild("Normal");
        mCenter = mUIRoot.transform.FindChild("Center");
        mTopRoot = mUIRoot.transform.FindChild("Top");
        mCoverRoot = mUIRoot.transform.FindChild("Cover");
        UIEvent = mUIRoot.transform.FindChild("EventSystem");
        UIRootScript = Tools.GetComponentSafe<UIRoot>(mUIRoot.gameObject);
    }
    void Start()
    {
        InputManager.Instance.RegisterAction(InputEvent.Submit, OnSubmit);
        InputManager.Instance.RegisterAction(InputEvent.Right, OnRight);
        InputManager.Instance.RegisterAction(InputEvent.Down, OnDown);
        InputManager.Instance.RegisterAction(InputEvent.Up, OnUp);
        InputManager.Instance.RegisterAction(InputEvent.Left, OnLeft);
        InputManager.Instance.RegisterAction(InputEvent.Cancel, OnCancel);
        InputManager.Instance.RegisterAction(InputEvent.Menu, OnMenu);
    }
    void OnDestroy()
    {
        mUIFormList = null;
        mUIInputStack = null;
        mDownLoadingUI = null;
        mHideList = null;
        ClickBack = null;
        InputManager.Instance.UnRegisterAction(InputEvent.Submit, OnSubmit);
        InputManager.Instance.UnRegisterAction(InputEvent.Right, OnRight);
        InputManager.Instance.UnRegisterAction(InputEvent.Down, OnDown);
        InputManager.Instance.UnRegisterAction(InputEvent.Up, OnUp);
        InputManager.Instance.UnRegisterAction(InputEvent.Left, OnLeft);
        InputManager.Instance.UnRegisterAction(InputEvent.Cancel, OnCancel);
        InputManager.Instance.UnRegisterAction(InputEvent.Menu, OnMenu);
    }
    /// <summary>
    /// 打开一个UI窗体
    /// </summary>
    /// <param name="uiFormName">窗体名称</param>
    /// <param name="bShow">直接显示</param>
    /// <param name="param">窗体显示数据</param>
    public void OpenUIForm(string uiFormName, bool bShow = true, object param = null, bool bload = false)
    {
        if (string.IsNullOrEmpty(uiFormName))
            return;
        if (bShow && !bload)
        {
            if (mUIInputStack.Contains(uiFormName))
                mUIInputStack.Remove(uiFormName);
            mUIInputStack.Add(uiFormName);
        }
        BaseUIForm baseUIForm = null;
        mUIFormList.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm == null)
        {
            if (mDownLoadingUI.Contains(uiFormName))
                return;
            mDownLoadingUI.Add(uiFormName);
            ManagerAssistant.ResLoadManager.LoadUIAsync("common/uiperfab/" + uiFormName, uiFormName, bShow, param, OnUIFormLoaded);
            return;
        }
        if (!baseUIForm.LockInput)
        {
            if (mUIInputStack.Contains(uiFormName))
                mUIInputStack.Remove(uiFormName);
        }
        //根据不同的UI窗体的显示模式，分别作不同的加载处理
        switch (baseUIForm.ShowType)
        {
            case UIShowType.Normal:
                {

                }
                break;
            case UIShowType.HideOther:              //“隐藏其他”窗口模式
                {
                    mHideList.Clear();
                    foreach (var baseUI in mUIFormList.Values)
                    {
                        if (baseUI.IsShow && baseUI.FormType == UIType.Normal
                            || baseUI.FormType == UIType.Center)
                        {
                            mHideList.Add(baseUI);
                            baseUI.OnHide();
                        }
                    }
                }
                break;
            default:
                break;
        }
        if (baseUIForm.FormType == UIType.Cover)
            mCoverRoot.transform.FindChild("_UIMask").gameObject.SetActive(true);
        baseUIForm.transform.SetAsLastSibling();
        if (bShow)
            baseUIForm.OnShow(param);
    }
    /// <summary>
    /// 关闭一个窗体
    /// </summary>
    /// <param name="uiFormName">窗体名</param>
    /// <param name="bDestroy">是否删除这个窗体</param>
    public void CloseUIForm(string uiFormName, bool bDestroy = false)
    {
        BaseUIForm baseUIForm;                          //窗体基类
        //参数检查
        if (string.IsNullOrEmpty(uiFormName)) return;
        //“所有UI窗体”集合中，如果没有记录，则直接返回
        mUIFormList.TryGetValue(uiFormName, out baseUIForm);
        if (baseUIForm == null)
            return;
        baseUIForm.OnHide();
        if (mUIInputStack.Contains(uiFormName))
            mUIInputStack.Remove(uiFormName);
        //根据窗体不同的显示类型，分别作不同的关闭处理
        switch (baseUIForm.ShowType)
        {
            case UIShowType.Normal:
                break;
            case UIShowType.HideOther:
                {
                    //foreach (var baseUI in mHideList)
                    //    baseUI.OnShow(null);
                }
                break;
            default:
                break;
        }
        if (baseUIForm.FormType == UIType.Cover)
            mCoverRoot.transform.FindChild("_UIMask").gameObject.SetActive(false);

        if (bDestroy)
        {
            mUIFormList.Remove(uiFormName);
            GameObject.Destroy(baseUIForm.gameObject);
        }
    }
    public Sprite GetUISprite(string str)
    {
        var tran = gUITexture.transform.FindChild(str);
        if (tran == null)
            return null;
        else
            return tran.GetComponent<SpriteRenderer>().sprite;
    }
    public void InitUIsprit()
    {
        ManagerAssistant.ResLoadManager.LoadAsync<GameObject>("common/UIPerfab/uitexture", "uitexture", (load) =>
        {
            gUITexture = GameObject.Instantiate(load);
            gUITexture.transform.SetParent(mUIRoot.transform);
            gUITexture.SetActive(false);
        });
    }
    void OnUIFormLoaded(GameObject obj, bool bShow, object param)
    {
        BaseUIForm baseUIForm = null;                     
        GameObject uiObj = GameObject.Instantiate<GameObject>(obj);//创建的UI克隆体预设
        if (mUIRoot != null && uiObj != null)
        {
            if (mDownLoadingUI.Contains(obj.name))
                mDownLoadingUI.Remove(obj.name);
            baseUIForm = uiObj.GetComponent<BaseUIForm>();
            if (baseUIForm == null)
            {
                Debug.Log("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 uiFormName=" + obj.name);
                return;
            }
            baseUIForm.Init();
            //if (!baseUIForm.LockInput)
            //{
            //    if (mUIInputStack.Contains(obj.name))
            //        mUIInputStack.Remove(obj.name);
            //}
            switch (baseUIForm.FormType)
            {
                case UIType.Normal:
                    uiObj.transform.SetParent(mNormalRoot, false); break;
                case UIType.Center:
                    uiObj.transform.SetParent(mCenter, false); break;
                case UIType.Top:
                    uiObj.transform.SetParent(mTopRoot, false);break;
                case UIType.Cover:
                    {
                        uiObj.transform.SetParent(mCoverRoot, false);
                        //mCoverRoot.transform.FindChild("_UIMask").gameObject.SetActive(true);
                    } break;
                default:
                    break;
            }
            uiObj.transform.localPosition = Vector3.zero;
            uiObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
            uiObj.transform.localScale = Vector3.one;
            //把克隆体，加入到“所有UI窗体”（缓存）集合中。
            if (!mUIFormList.ContainsKey(obj.name))
                mUIFormList.Add(obj.name, baseUIForm);
            uiObj.SetActive(bShow);
            if (bShow)
                OpenUIForm(obj.name, bShow, param,true);
        }
        //else
        //    Debug.Log("mUIRoot==null! or load error");
    }
    public void WaitBack(Action timeout)
    {
        OpenUIForm("WaitMsgUIForm", true, timeout);
    }
    public void PromptInfo(string str, bool bHide = true)
    {
        if (string.IsNullOrEmpty(str))
            CloseUIForm("PromptUIForm");
        else
        {
            if (bHide)
                str = "[hide]" + str;
            OpenUIForm("PromptUIForm", true, str);
        }
    }
    public void ShowNotice(string str)
    {
        OpenUIForm("NoticeUIForm", true, str);
    }
    public void AddShortCut(GameObject obj, Action call)
    {
        ClickBack = call;
        Transform tran = obj.transform.FindChild("Shortcut");
        if (tran != null)
        {
            var cut = tran.GetComponent<Shortcut>();
            if (cut != null)
                cut.UpdateInfo();
        }
        else
            ManagerAssistant.ResLoadManager.LoadAsync<GameObject>("common/uiperfab/Shortcut", "Shortcut", (load) =>
            {
                GameObject o = GameObject.Instantiate(load) as GameObject;
                Tools.ResetGameObj(o, obj.transform);
                o.name = "Shortcut";
                Tools.GetComponentSafe<Shortcut>(o);
                o.transform.SetSiblingIndex(1);
            });
    }
    public void Whether(string info, Action yes,Action no)
    {
        DelOnSubmit = yes;
        DelOnCancel = no;
        OpenUIForm("BackUIForm", true, info);
    }
    public void ShowMsgBox(MsgBoxInfo info)
    {
        OpenUIForm("MsgBoxUIForm", true, info);
    }
    public void HideAllUI()
    {
        foreach (var ui in mUIFormList.Values)
        {
            ui.OnHide();
        }
    }
    void OnSubmit()
    {
        OnKey(InputEvent.Submit);
    }
    void OnRight()
    {
        OnKey(InputEvent.Right);
    }
    void OnLeft()
    {
        OnKey(InputEvent.Left);
    }
    void OnDown()
    {
        OnKey(InputEvent.Down);
    }
    void OnUp()
    {
        OnKey(InputEvent.Up);
    }
    void OnCancel()
    {
        OnKey(InputEvent.Cancel);
    }
    void OnMenu()
    {

    }
    void OnKey(InputEvent input)
    {
        var lsit = mUIFormList.GetEnumerator();
        for (int i = 0; i < mUIFormList.Count; i++)
        {
            lsit.MoveNext();
            KeyValuePair<string, BaseUIForm> info = lsit.Current;
            if (null != info.Value && info.Value.IsShow && mUIInputStack.Count > 0)
            {
                string str = mUIInputStack[mUIInputStack.Count - 1];
                if (CoverInput)
                {
                    if (info.Value.FormType == UIType.Cover)
                    {
                        InputCall(input, info.Value);
                        return;
                    }
                }
                else if (info.Value.name.Contains(str))
                {
                    InputCall(input, info.Value);
                    return;
                }
            }
        }
    }
    void InputCall(InputEvent input,BaseUIForm form)
    {
        switch (input)
        {
            case InputEvent.Submit:
                form.OnSubmit(); break;
            case InputEvent.Up:
                form.OnUp(); break;
            case InputEvent.Down:
                form.OnDown(); break;
            case InputEvent.Left:
                form.OnLeft(); break;
            case InputEvent.Right:
                form.OnRight(); break;
            case InputEvent.Cancel:
                form.OnCancel(); break;
            default:
                break;
        }
    }

}