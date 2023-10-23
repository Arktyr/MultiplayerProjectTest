namespace _Project.CodeBase.Infrastructure.StateMachines.FSM.States
{
    public interface IStateWithArgument<in TArgs> : IExitableState
    {
        void Enter(TArgs args);
    }
}