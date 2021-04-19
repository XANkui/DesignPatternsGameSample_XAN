using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPattern_Sample_XAN
{ 

	public class GamePauseUI : IBaseGameUI
	{

        private Text mCurStage;
        private Button mCoutinueButton;
        private Button mBackMenuButton;
        public override void Init()
        {
            base.Init();
            GameObject canvas = GameObject.Find("Canvas");
            mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");

            mCurStage = UITool.FindChild<Text>(mRootUI, "CurStage");
            mCoutinueButton = UITool.FindChild<Button>(mRootUI, "CoutinueButton");
            mBackMenuButton = UITool.FindChild<Button>(mRootUI, "BackMenuButton");

            Hide();
        }
    }
}
