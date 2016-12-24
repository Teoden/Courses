using UnityEngine;
using System.Collections;
using Courses;

public class PlayerController : MonoBehaviour {

    private IFacade facade;
    private IPlayerModel playerModel;

    public void Start()
    {
        facade = Facade.GetInstanse();
        playerModel = facade.GetModel<IPlayerModel>();
    }
	public void OnGUI()
    {
        if(playerModel.IsLoaded)
        {
            GUI.Label(new Rect(10, 10, 150, 150), string.Format(" Name {0} Progress {1}", playerModel.PlayerName, playerModel.PlayerProgress));
        }
    }
}
