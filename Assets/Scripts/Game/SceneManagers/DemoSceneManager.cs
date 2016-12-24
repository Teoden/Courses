using UnityEngine;
using Courses;

public class DemoSceneManager : MonoBehaviour {

    private IFacade facade;
    private IPlayerModel playerModel;
    
    public void Awake () {
        facade = Facade.GetInstanse();
        facade.RegisterModel<IPlayerModel, PlayerModel>();
        playerModel = facade.GetModel<IPlayerModel>();
        playerModel.LoadData("Hello", 5);
    }	
	
}
