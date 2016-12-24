using System;
using System.Collections.Generic;


namespace Courses
{
    public interface IPlayerModel: IModel
    {

        string PlayerName { get; }
        int PlayerProgress { get; }
        void LoadData(string name, int progress);

    }
}
