using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class GameManager : MonoBehaviour
	{
		private SceneStateController mSceneStateController;


		private void Awake()
        {
			// 过场不销毁
			DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
		{
			InitSceneStateController();
		}

		// Update is called once per frame
		void Update()
		{
			UpdateSceneStateController();
		}

		#region SceneState

		void InitSceneStateController() {
			mSceneStateController = new SceneStateController();
			mSceneStateController.SetState(new StartGameState(mSceneStateController), false);
		}

		void UpdateSceneStateController() {
            if (mSceneStateController !=null)
            {
				mSceneStateController.StateUpdate();
            }
		}

		#endregion

	}
}
