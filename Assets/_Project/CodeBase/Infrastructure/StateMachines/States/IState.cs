namespace _Project.CodeBase.Infrastructure.StateMachines.States
{
    public interface IState : IExitableState
    { 
        void Enter();
    }
}