namespace Euler.Common
{
	public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public TResult Result { get; protected set; }

        public abstract ICommand<TResult> Run();
    }

}
