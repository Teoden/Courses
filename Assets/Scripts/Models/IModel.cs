using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses
{
    public interface IModel
    {
        bool IsLoaded { get; }
        void Init(object data = null);
        void Dispose();
    }
}
