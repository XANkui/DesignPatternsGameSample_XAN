using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPattern_Sample_XAN
{ 

	public class CampInfoUI : IBaseGameUI
	{
        private Image mCampIcon;
        private Text mCampName;
        private Text mCampLevel;
        private Text mWeaponLevel;
        private Button mCampUpgradeBtn;
        private Button mWeaponUpgradeBtn;
        private Button mTrainBtn;
        private Text mTrainBtnText;
        private Button mCancelTrainBtn;
        private Text mAliveCount;
        private Text mTrainingCount;
        private Text mTrainingTime;

        private ICamp mCurCamp;

        public override void Init()
        {
            base.Init();
            GameObject canvas = GameObject.Find("Canvas");
            mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

            mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
            mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
            mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
            mWeaponLevel = UITool.FindChild<Text>(mRootUI, "WeaponLv");
            mCampUpgradeBtn = UITool.FindChild<Button>(mRootUI, "CampLvBtn");
            mWeaponUpgradeBtn = UITool.FindChild<Button>(mRootUI, "WeaponLvBtn");
            mTrainBtn = UITool.FindChild<Button>(mRootUI, "TrainBtn");
            mCancelTrainBtn = UITool.FindChild<Button>(mRootUI, "CancelTrainBtn");
            mTrainBtnText = UITool.FindChild<Text>(mRootUI, "TrainBtnText");
            mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
            mTrainingCount = UITool.FindChild<Text>(mRootUI, "TrainingCount");
            mTrainingTime = UITool.FindChild<Text>(mRootUI, "TrainTime");

            mTrainBtn.onClick.AddListener(OnTrainBtnClick);
            mCancelTrainBtn.onClick.AddListener(OnCancelTrainBtnClick);
            mCampUpgradeBtn.onClick.AddListener(OnCampUpgradeBtnClick);
            mWeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeBtnClick);

            Hide();
        }


        public override void Update()
        {
            base.Update();

            if (mCurCamp!=null)
            {
                ShowTrainingInfo();
            }
        }

        public void ShowCampInfo(ICamp camp)
        {
            Show();

            mCurCamp = camp;

            mCampIcon.sprite = FactoryManager.AssetFactory.LoadSprite(camp.IconSprite);
            mCampName.text = camp.Name;
            mCampLevel.text = camp.Lv.ToString();
            ShowWeaponLevel(camp.WeaponType);

            ShowTrainingInfo();
        }

        void ShowWeaponLevel(WeaponType weaponType) {
            switch (weaponType)
            {
                case WeaponType.Gun:
                    mWeaponLevel.text = "短枪";
                    break;
                case WeaponType.Rifle:
                    mWeaponLevel.text = "长枪";
                    break;
                case WeaponType.Rocket:
                    mWeaponLevel.text = "火箭炮";
                    break;
                case WeaponType.Max:
                    break;
                default:
                    break;
            }
        }


        void ShowTrainingInfo() {
            mTrainingCount.text = mCurCamp.TrainCount.ToString();
            mTrainingTime.text = mCurCamp.TrainRemainTime.ToString();
            if (mCurCamp.TrainCount <= 0)
            {
                mCancelTrainBtn.interactable = false;
            }
            else {
                mCancelTrainBtn.interactable = true;
            }

            mTrainBtnText.text = "训练\n" + mCurCamp.EnergyCostTrainSoldier + "点能量";
        }

        void OnTrainBtnClick() {
            int energy = mCurCamp.EnergyCostTrainSoldier;
            if (PlayGameFacade.TakeEnergy(energy))
            {
                mCurCamp.Train();
            }
            else {
                PlayGameFacade.ShowMsg("Energy is not enough !! Need Energy : "+ energy);
            }
            
        }

        void OnCancelTrainBtnClick() {
            int energy = mCurCamp.EnergyCostTrainSoldier;
            PlayGameFacade.RecycleEnergy(energy);
            mCurCamp.CancelTrain();
        }

        void OnCampUpgradeBtnClick() {
            int energy = mCurCamp.EnergyCostUpgradeCamp;
            if (energy<0)
            {
                PlayGameFacade.ShowMsg("Camp Level is max !!");
                return;
            }

            if (PlayGameFacade.TakeEnergy(energy))
            {
                mCurCamp.UpgradeCamp();
            }
            else
            {
                PlayGameFacade.ShowMsg("Energy is not enough !! Need Energy : " + energy);
            }

            ShowCampInfo(mCurCamp);
        }

        void OnWeaponUpgradeBtnClick()
        {
            int energy = mCurCamp.EnergyCostUpgradeWeapon;
            if (energy < 0)
            {
                PlayGameFacade.ShowMsg("Weapon Level is max !!");
                return;
            }

            if (PlayGameFacade.TakeEnergy(energy))
            {
                mCurCamp.UpgradeWeapon();
            }
            else
            {
                PlayGameFacade.ShowMsg("Energy is not enough !! Need Energy : " + energy);
            }

            ShowCampInfo(mCurCamp);
        }
    }
}
