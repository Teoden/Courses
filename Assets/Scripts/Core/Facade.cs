using System;
using System.Collections.Generic;


namespace Courses
{
    public class Facade: IFacade
    {
        private static IFacade s_current;
        
        private Facade()
        {
            modelMap = new Dictionary<Type, IModel>();            
        }        

        public static IFacade GetInstanse()
        {
            if(s_current == null)
            {
                s_current = new Facade();
            }
            return s_current;            
        }

        private Dictionary<Type, IModel> modelMap;

        public void DisposeModel<IFace>()
            where IFace : class, IModel
        {
            IModel model;
            Type tModel = typeof(IFace);
            if (modelMap.TryGetValue(typeof(IFace), out model))
            {
                model.Dispose();
                modelMap.Remove(tModel);
            }
        }

        public T GetModel<T>()
            where T : class, IModel
        {
            IModel mod;
            modelMap.TryGetValue(typeof(T), out mod);
            return mod as T;
        }

        public void RegisterModel<IFace, TCls>()
            where IFace : class, IModel
            where TCls : class, IModel, IFace, new()
        {
            Type tModel = typeof(IFace);
            if (modelMap.ContainsKey(tModel))
            {
                throw new Exception("Model with type '" + tModel + "' is already linked to " + modelMap[tModel] + " .");				
            }

            object oRes = new TCls();
            IFace res = (IFace)oRes;
            string id = typeof(TCls).ToString();
            if (res != null)
            {
                res.Init();
                modelMap.Add(typeof(IFace), res);
            }
            else
            {
                string msg = String.Format("Model with id '{0}' could not be created", id);
                throw new Exception(msg);
            }
        }
    }
}
