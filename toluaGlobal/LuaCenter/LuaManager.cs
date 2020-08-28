using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Res.Script.Global.LuaCenter
{
    struct LuaFileDataType
    {
        string fileName;

        enum ELifetimeFunctions
        {
            Awake,
            Start,
            Update,
            FixedUpdate,                        
        }        

        enum EBasicFunctions
        {
            Init,
            Main,
        }
    }

    sealed public class LuaManager
    {
        protected static LuaManager ins;
        public static LuaManager GetIns()
        {
            if (ins == null)
            {
                ins = new LuaManager();
            }
            return ins;
        }

        string mLuaPath = Application.dataPath + @"/Updating/01/scripts/";

        LuaState m_luastate;
                       
        public LuaManager()
        {
            this.m_luastate = new LuaState();
            this.m_luastate.Start();
            LuaBinder.Bind(this.m_luastate);
            DelegateFactory.Init();
        }

        public LuaState GetLuaState()
        {
            return this.m_luastate;
        }

        public void ExecuteLuaByPath(string luapath, string filename)
        {            
            this.m_luastate.AddSearchPath(luapath);
            this.m_luastate.DoFile(filename);
        }

        /// <summary>
        /// Argument ArrayList : GameObject, string, int
        /// </summary>
        /// <param name="luapath"></param>
        /// <param name="filename"></param>
        /// <param name="funcname"></param>
        /// <param name="argv"></param>
        public void ExecuteLuaFunctionByPath(string luapath, string filename, string funcname, ArrayList argv)
        {                    
            int num;
            this.m_luastate.AddSearchPath(luapath);
            this.m_luastate.DoFile(filename);
            num = this.m_luastate.GetFunction(funcname).Invoke<GameObject, string, int, int>((GameObject)argv[0], argv[1].ToString(), (int)argv[2]);
            Debug.Log("The function executed " + num);
        }        

        public void InvokeLuaFunctions()
        {

        }
    }
}
