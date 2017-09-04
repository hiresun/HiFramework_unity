﻿//****************************************************************************
// Description:view可以有对应控制器,也可以没有.可以直接注册agent
// 但是仍旧是:控制前,agent不对表现层的view直接引用,而是采用派发消息的方式
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    public abstract class View : ObjectBaseMono, IReceive, IRegistAndDispatch, ITick
    {
        public ViewAgent Bind<T>() where T : ViewAgent, new()
        {
            var viewAgent = new T();
            viewAgent.Bind(this);
            return viewAgent;
        }
        public object Regist<T>(object paramKey) where T : Agent
        {
            return Facade.RegistAndDispatch.Regist<T>(paramKey);
        }
        public void Unregist(object paramKey)
        {
            Facade.RegistAndDispatch.Unregist(paramKey);
        }
        public void Dispatch(object paramKey, IMessage paramMessage = null)
        {
            Facade.RegistAndDispatch.Dispatch(paramKey, paramMessage);
        }
        //接收来自对应控制器和Agent的消息
        public virtual void OnMessage(IMessage paramMessage)
        {
        }

        public void AddToTickList(ITick param)
        {
            Facade.GameTick.AddToTickList(param);
        }

        public void RemoveFromTickList(ITick param)
        {
            Facade.GameTick.RemoveFromTickList(param);
        }

        public virtual void OnTick()
        {
        }
    }
}