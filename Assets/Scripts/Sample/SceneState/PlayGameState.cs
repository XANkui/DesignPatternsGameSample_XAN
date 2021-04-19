using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class PlayGameState : ISceneState
	{
        public PlayGameState(SceneStateController sceneStateController) : base(sceneStateController, SceneEnum.PlayGame.ToString()) { }


        private PlayGameFacade mPlayGameFacade;

        public PlayGameFacade PlayGameFacade { get {
                if (mPlayGameFacade==null)
                {
                    mPlayGameFacade = PlayGameFacade.Instance;
                }

                return mPlayGameFacade;
            }
        }

        public override void StateStart()
        {
            if (PlayGameFacade != null)
            {
                PlayGameFacade.Init();
            }
            else {
                Debug.LogError(GetType() + "/StateStart()/ mPlayGameFacade is null, Please Check ");
            }
        }

        public override void StateEnd()
        {
            if (PlayGameFacade != null)
            {
                PlayGameFacade.Release();
            }
            else
            {
                Debug.LogError(GetType() + "/StateEnd()/ mPlayGameFacade is null, Please Check ");
            }
        }

        public override void StateUpdate()
        {
            if (PlayGameFacade != null)
            {
                if (PlayGameFacade.IsPlayGameOver == true)
                {
                    mSceneStateController.SetState(new MainMenuState(mSceneStateController));
                }
                else { 
                    PlayGameFacade.Update();
                }

            }
            else
            {
                Debug.LogError(GetType() + "/StateUpdate()/ mPlayGameFacade is null, Please Check ");
            }
        }
    }
}
