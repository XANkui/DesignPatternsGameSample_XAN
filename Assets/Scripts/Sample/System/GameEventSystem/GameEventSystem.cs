using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern_Sample_XAN
{
    public enum GameEventType { 
        Null,
        EnemyKilled,
        SoldierKilled,
        NewStage
    }
	public class GameEventSystem : IGameSystem
	{
        private Dictionary<GameEventType, IGameEventSubject> mGameEventDict = new Dictionary<GameEventType, IGameEventSubject>();

        public override void Init()
        {
            base.Init();
            // InitGameEvents(); // 这样注册可能代码先后调用会出现错误，改为懒汉式注册，没有才注册
        }

        private void InitGameEvents() {
            mGameEventDict.Add(GameEventType.EnemyKilled, new EnemyKilledSubject()) ;
            mGameEventDict.Add(GameEventType.SoldierKilled, new SoldierKilledSubject()) ;
            mGameEventDict.Add(GameEventType.NewStage, new NewStageSubject()) ;
        }

        public void RegisterObserver(GameEventType gameEventType, IGameEventObserver observer) {
            IGameEventSubject sub = GetGameEventSubject(gameEventType);
            if (sub==null)
            {
                return;
            }

            sub.RegisterObserver(observer);
            observer.SetSubject(sub);
        }

        public void RemoveObserver(GameEventType gameEventType, IGameEventObserver observer)
        {
            IGameEventSubject sub = GetGameEventSubject(gameEventType);
            if (sub == null)
            {
                return;
            }

            sub.RemoveObserver(observer);
            observer.SetSubject(null);
        }

        public void NotifySubject(GameEventType gameEventType) {
            IGameEventSubject sub = GetGameEventSubject(gameEventType);
            if (sub == null)
            {
                return;
            }

            sub.Notify();
        }

        private IGameEventSubject GetGameEventSubject(GameEventType gameEventType) {

            if (mGameEventDict.ContainsKey(gameEventType)==false)
            {
                switch (gameEventType)
                {
             
                    case GameEventType.EnemyKilled:
                        mGameEventDict.Add(GameEventType.EnemyKilled, new EnemyKilledSubject());
                        break;
                    case GameEventType.SoldierKilled:
                        mGameEventDict.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                        break;
                    case GameEventType.NewStage:
                        mGameEventDict.Add(GameEventType.NewStage, new NewStageSubject());
                        break;
                    default:
                        Debug.LogError(GetType() + "/GetGameEventSubject()/ There is no one in mGameEventDict : " + gameEventType.ToString());
                        return null;
                }               
            }

            return mGameEventDict[gameEventType];
        }
    }
}
