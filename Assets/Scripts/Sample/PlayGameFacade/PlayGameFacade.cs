using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{ 

	public class PlayGameFacade
	{
		#region 字段

		private static PlayGameFacade _instance = new PlayGameFacade();

		private bool mIsPlayGameOver = false;



		private ArchievementSystem mArchievementSystem;
		private CampSystem mCampSystem;
		private CharacterSystem mCharacterSystem;
		private GameEventSystem mGameEventSystem;
		private StageSystem mStageSystem;
		private EnergySystem mEnergySystem;

		private CampInfoUI mCampInfoUI;
		private GamePauseUI mGamePauseUI;
		private GameStateInfoUI mGameStateInfoUI;
		private SoldierInfoUI mSoldierInfoUI;

		#endregion

		#region 属性


		public static PlayGameFacade Instance { get {
				return _instance;
			} 
		}

		public bool IsPlayGameOver {
			get { return mIsPlayGameOver; }
		}



		public ArchievementSystem ArchievementSystem { get {
				if (mArchievementSystem == null) {
					mArchievementSystem = new ArchievementSystem();
				}

				return mArchievementSystem;
			} 
		}
		public CampSystem CampSystem
		{
			get
			{
				if (mCampSystem == null)
				{
					mCampSystem = new CampSystem();
				}

				return mCampSystem;
			}
		}
		public CharacterSystem CharacterSystem
		{
			get
			{
				if (mCharacterSystem == null)
				{
					mCharacterSystem = new CharacterSystem();
				}

				return mCharacterSystem;
			}
		}
		public GameEventSystem GameEventSystem
		{
			get
			{
				if (mGameEventSystem == null)
				{
					mGameEventSystem = new GameEventSystem();
				}

				return mGameEventSystem;
			}
		}
		public StageSystem StageSystem
		{
			get
			{
				if (mStageSystem == null)
				{
					mStageSystem = new StageSystem();
				}

				return mStageSystem;
			}
		}

		public EnergySystem EnergySystem {
			get
			{
				if (mEnergySystem == null)
				{
					mEnergySystem = new EnergySystem();
				}

				return mEnergySystem;
			}
		}

		public CampInfoUI CampInfoUI
		{
			get
			{
				if (mCampInfoUI == null)
				{
					mCampInfoUI = new CampInfoUI();
				}

				return mCampInfoUI;
			}
		}
		public GamePauseUI GamePauseUI
		{
			get
			{
				if (mGamePauseUI == null)
				{
					mGamePauseUI = new GamePauseUI();
				}

				return mGamePauseUI;
			}
		}
		public GameStateInfoUI GameStateInfoUI
		{
			get
			{
				if (mGameStateInfoUI == null)
				{
					mGameStateInfoUI = new GameStateInfoUI();
				}

				return mGameStateInfoUI;
			}
		}
		public SoldierInfoUI SoldierInfoUI
		{
			get
			{
				if (mSoldierInfoUI == null)
				{
					mSoldierInfoUI = new SoldierInfoUI();
				}

				return mSoldierInfoUI;
			}
		}

		#endregion



		public void Init() {
			GameEventSystem.Init();

			ArchievementSystem.Init();
			CampSystem.Init();
			CharacterSystem.Init();			
			StageSystem.Init();
			EnergySystem.Init();

			CampInfoUI.Init();
			GamePauseUI.Init();
			GameStateInfoUI.Init();
			SoldierInfoUI.Init();

			LoadMemento();
		}

		public void Release() {
			ArchievementSystem.Release();
			CampSystem.Release();
			CharacterSystem.Release();
			GameEventSystem.Release();
			StageSystem.Release();
			EnergySystem.Release();

			CampInfoUI.Release();
			GamePauseUI.Release();
			GameStateInfoUI.Release();
			SoldierInfoUI.Release();

			CreateMemento();
		}

		public void Update() {
			ArchievementSystem.Update();
			CampSystem.Update();
			CharacterSystem.Update();
			GameEventSystem.Update();
			StageSystem.Update();
			EnergySystem.Update();

			CampInfoUI.Update();
			GamePauseUI.Update();
			GameStateInfoUI.Update();
			SoldierInfoUI.Update();
		}


		public Vector3 GetEnemyDestinationPosition() {
			// TODO 获取敌人进攻的目标据点位置
			return mStageSystem.TargetPosition;
		}

		public void ShowCampInfo(ICamp camp) {
			mCampInfoUI.ShowCampInfo(camp);
		}

		public void AddSoldierToCharactorSystem(ISoldier soldier) {
			mCharacterSystem.AddSoldier(soldier);
		}

		public void AddEnemyToCharactorSystem(IEnemy enemy)
		{
			mCharacterSystem.AddEnemy(enemy);
		}

		public void RemoveEnemyToCharactorSystem(IEnemy enemy)
		{
			mCharacterSystem.RemoveEnemy(enemy);
		}

		public bool TakeEnergy(int value) {
			return EnergySystem.TakeEnergy(value);
		}

		public void RecycleEnergy(int value) {
			EnergySystem.RecycleEnergy(value);
		}

		public void ShowMsg(string msg) {
			mGameStateInfoUI.ShowMsg(msg);
		}

		public void UpdateEnergySliderTextInfo(int nowEnergy, int maxEnergy) {
			mGameStateInfoUI.UpdateEnergySliderTextInfo(nowEnergy, maxEnergy);
		}

		public void RegisterObserver(GameEventType gameEventType, IGameEventObserver observer) {
			mGameEventSystem.RegisterObserver(gameEventType, observer);
		}
		public void RemoveObserver(GameEventType gameEventType, IGameEventObserver observer) {
			mGameEventSystem.RemoveObserver(gameEventType,observer);
		}
		public void NotifySubject(GameEventType gameEventType) {
			mGameEventSystem.NotifySubject(gameEventType);
		}

		public void RunVisitor(ICharactorVisitor visitor) {
			mCharacterSystem.RunVisitor(visitor);
		}

		private void LoadMemento() {
			AchievementMemento memento = new AchievementMemento();
			memento.Load();
			mArchievementSystem.SetMemento(memento);
		}

		private void CreateMemento() {
			AchievementMemento memento = mArchievementSystem.CreateMemento();
			memento.Save();
		}
	}
}
