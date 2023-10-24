namespace _Project.CodeBase.Infrastructure.StateMachines.States
{
    public interface IStateWithArgument<in TArgs> : IExitableState
    {
        void Enter(TArgs args);
    }
}