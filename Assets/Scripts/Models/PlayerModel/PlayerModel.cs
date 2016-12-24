using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Courses
{
    class PlayerModel : IPlayerModel
    {
        private string _playerName;
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
        }

        private int _playerProgress;
        public int PlayerProgress
        {
            get
            {
                return _playerProgress;
            }
        }


        public bool IsLoaded { get; private set; }
        

        public void Dispose()
        {
            IsLoaded = false;
        }

        public void Init(object data = null)
        {
            _playerName = null;
            _playerProgress = int.MinValue;
        }

        public void LoadData(string name, int progress)
        {
            this._playerName = name;
            this._playerProgress = progress;
            IsLoaded = true;
        }
    }
}
