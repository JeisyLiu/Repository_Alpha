using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIO
{
    public static ResourceIO instanceResourceIO;
    public static ResourceIO getInstance()
    {
        if (instanceResourceIO == null)
        {
            instanceResourceIO = new ResourceIO();
        }
        return instanceResourceIO;
    }

    public GameObject LoadResourceToView(string path, Transform rootObjTransform)
    {
        GameObject gameobj = new GameObject();
        gameobj = GameObject.Instantiate(Resources.Load<GameObject>(path));
        gameobj.transform.SetParent(rootObjTransform);
        //gameobj.transform.localPosition = Vector3.zero;
        //gameobj.transform.localScale = Vector3.zero;
        return gameobj;
    }
}
