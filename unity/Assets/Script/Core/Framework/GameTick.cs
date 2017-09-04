﻿//****************************************************************************
// Description:游戏中的tick管理
// Author: hiramtan@live.com
//****************************************************************************
using System.Collections.Generic;

namespace HiFramework
{
    public class GameTick :ObjectBase, ITick
    {
        private IList<ITick> _tickList = new List<ITick>();

        public void OnTick()
        {
            for (int i = 0; i < _tickList.Count; i++)
                _tickList[i].OnTick();
        }

        public void AddToTickList(ITick paramTick)
        {
            if (!_tickList.Contains(paramTick))
                _tickList.Add(paramTick);
        }
        public void RemoveFromTickList(ITick paramTick)
        {
            if (_tickList.Contains(paramTick))
                _tickList.Remove(paramTick);
        }

        protected override void OnDispose()
        {
            _tickList.Clear();
            _tickList = null;
        }
    }
}