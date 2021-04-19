using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPattern_Sample_XAN
{ 

	public class SoldierInfoUI : IBaseGameUI
	{

        private Image mSoldierIcon;
        private Text mSoldierName;
        private Text mHp;
        private Slider mHPSlider;
        private Text mLevel;
        private Text mAtk;
        private Text mAtkRange;
        private Text mMoveSpeed;

        public override void Init()
        {
            base.Init();
            GameObject canvas = GameObject.Find("Canvas");
            mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

            mSoldierIcon = UITool.FindChild<Image>(mRootUI, "SoldierIcon");
            mSoldierName = UITool.FindChild<Text>(mRootUI, "SoldierName");
            mHp = UITool.FindChild<Text>(mRootUI, "Hp");
            mHPSlider = UITool.FindChild<Slider>(mRootUI, "HPSlider");
            mLevel = UITool.FindChild<Text>(mRootUI, "Level");
            mAtk = UITool.FindChild<Text>(mRootUI, "Atk");
            mAtkRange = UITool.FindChild<Text>(mRootUI, "AtkRange");
            mMoveSpeed = UITool.FindChild<Text>(mRootUI, "MoveSpeed");

            Hide();
        }
    }
}
