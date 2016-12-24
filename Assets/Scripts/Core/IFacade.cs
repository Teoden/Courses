using System;
using System.Collections.Generic;


namespace Courses
{
    public interface IFacade
    {     
        void RegisterModel<IFace, TCls>()
            where IFace : class, IModel
            where TCls : class, IModel, IFace, new();

        void DisposeModel<IFace>()
            where IFace : class, IModel;

        T GetModel<T>()
            where T : class, IModel;

    }
}
