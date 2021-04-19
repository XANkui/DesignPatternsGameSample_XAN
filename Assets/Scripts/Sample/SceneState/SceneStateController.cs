using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DesignPattern_Sample_XAN
{ 

	public class SceneStateController 
	{
		private ISceneState mCurState;
        private AsyncOperation mAO;
        private bool mIsRunStart = false;

        public SceneStateController() { }

        public void SetState(ISceneState sceneState, bool isToLoadScene = true) {
            // 上一个状态结束
            StateEnd();

            mCurState = sceneState;
            if (isToLoadScene == true)
            {
                LoadAsyncScene(mCurState.SceneName);
            }
            else {
                StateStart();
                
            }
        }

        public void StateUpdate()
        {
            // 场景加载中，不进行状态更新
            if (mAO !=null && mAO.isDone ==false)
            {
                return;
            }

            UpdateIsLoadSceneCompleted();


            if (mCurState != null)
            {
                mCurState.StateUpdate();
            }
        }

        void StateStart()
        {
            if (mCurState != null)
            {
                mCurState.StateStart();
            }

            mIsRunStart = true;
            mAO = null;
        }

        void StateEnd()
        {
            if (mCurState != null)
            {
                mCurState.StateEnd();
            }
        }


        void LoadAsyncScene(string sceneName) {
            mAO = SceneManager.LoadSceneAsync(sceneName);
            mIsRunStart = false;
        }

        void UpdateIsLoadSceneCompleted() {
            if (mIsRunStart==false && mAO !=null && mAO.isDone ==true)
            {
                StateStart();
                
            }
        }
        
    }
}
