using Assets.Res.Script.Data.Po;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Res.Script.Global
{
    public static class Path_Prefabs
    {        
        public static string BlockConsume = "UI/Detail/BlockConsumePanel";
        public static string BlockEquipment = "UI/Detail/BlockEquipPanel";        
    }

    public class ObjectPool
    {
        public static ObjectPool Ins;
        public static ObjectPool GetIns()
        {
            if (Ins == null)
            {
                Ins = new ObjectPool();
            }
            return Ins;
        }

        Dictionary<int, List<BaseData>> m_itemdic;
        Dictionary<string, List<GameObject>> m_objectpool; // path , gameobject which moved to far away

        public ObjectPool()
        {
            this.m_itemdic = new Dictionary<int, List<BaseData>>();
            this.m_objectpool = new Dictionary<string, List<GameObject>>();
        }
        
        public GameObject GetPrefabByPath(string path)
        {
            if (this.m_objectpool.ContainsKey(path))
            {
                if (this.m_objectpool[path].Count > 0) // the pool may contains the deactivated game object
                {
                    for (int i = 0; i < this.m_objectpool[path].Count; i++)
                    {
                        if (!this.m_objectpool[path][i].activeSelf)
                        {
                            this.m_objectpool[path][i].SetActive(true);
                            return this.m_objectpool[path][i];
                        }
                    }
                }

                // pool contains the path only but object list is empty or the list does not have deactivated object
                GameObject newadded = GameObject.Instantiate(Resources.Load<GameObject>(path));
                this.m_objectpool[path].Add(newadded);
                return newadded;
            }

            // no path nor poollist
            GameObject brandnew = GameObject.Instantiate(Resources.Load<GameObject>(path));
            this.m_objectpool.Add(path, new List<GameObject>() { brandnew });
            return brandnew;
        }

        public void RecycleGameObject(string path, GameObject target)
        {
            if (this.m_objectpool.ContainsKey(path))
            {
                target.transform.position = new Vector3(10000, 10000, 10000);
                //this.m_objectpool[path].Add(target);
                target.SetActive(false);
            }
            else
            {
                this.m_objectpool.Add(path, new List<GameObject>() { target });
                target.transform.position = new Vector3(10000, 10000, 10000);
                target.SetActive(false);
            }
        }

        public bool RemoveGameObject(string path, GameObject target)
        {
            try
            {                
                this.m_objectpool[path].Remove(target);
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public bool ClearAll()
        {
            try
            {
                this.m_objectpool.Clear();
                this.m_objectpool = new Dictionary<string, List<GameObject>>();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
