namespace _Project.CodeBase.Infrastructure.StateMachines.FSM.States
{
    public interface IState : IExitableState
    { 
        void Enter();
    }
}