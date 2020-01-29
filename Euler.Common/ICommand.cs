namespace Euler.Common
{
    public interface ICommand<TResult>
    {
        TResult Result { get; }
        ICommand<TResult> Run();
    }
}
