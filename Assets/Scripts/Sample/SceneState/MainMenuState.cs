using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPattern_Sample_XAN
{ 

	public class MainMenuState : ISceneState
	{
        public MainMenuState(SceneStateController sceneStateController) : base(sceneStateController, SceneEnum.MainMenu.ToString()) { }

        public override void StateStart()
        {
            GameObject.Find("PlayGameButton").GetComponent<Button>().onClick.AddListener(()=>{

                mSceneStateController.SetState(new PlayGameState(mSceneStateController));
            });
        }

        public override void StateEnd()
        {
            
        }

        public override void StateUpdate()
        {
            
        }
    }
}
