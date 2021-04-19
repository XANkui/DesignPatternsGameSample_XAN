using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public abstract class ISceneState 
	{
		public string SceneName;
		protected SceneStateController mSceneStateController;

		public ISceneState(SceneStateController sceneStateController, string sceneName) {
			mSceneStateController = sceneStateController;
			SceneName = sceneName;
		}

		public abstract void StateStart();
		public abstract void StateEnd();
		public abstract void StateUpdate();
	}
}
