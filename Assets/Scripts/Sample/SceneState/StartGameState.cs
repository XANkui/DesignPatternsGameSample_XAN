using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPattern_Sample_XAN
{ 

	public class StartGameState : ISceneState
	{
        public StartGameState(SceneStateController sceneStateController) : base(sceneStateController, SceneEnum.StartGame.ToString()) { }


        private Image mLogo;
        private float mSmoothSpeed = 1f;
        private float mWaitTimeToNextScene = 2f;
        private float mWaitTimer = 0f;
        public override void StateStart()
        {
            mLogo = GameObject.Find("LogoImage").GetComponent<Image>();
            mLogo.color = Color.black;
            mWaitTimer = mWaitTimeToNextScene;
        }

        public override void StateEnd()
        {
            
        }

        public override void StateUpdate()
        {
            if (mLogo != null)
            {
                mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothSpeed * Time.deltaTime);
                mWaitTimer -= Time.deltaTime;
                if (mWaitTimer < 0)
                {
                    mSceneStateController.SetState(new MainMenuState(mSceneStateController));
                    mWaitTimer = mWaitTimeToNextScene;
                }
            }
            else {
                Debug.LogError(GetType()+ "/StateUpdate()/ mLogo is null, Please Check ");
            }
        }
    }
}
