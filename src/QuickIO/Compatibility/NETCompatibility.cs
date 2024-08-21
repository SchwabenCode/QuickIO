namespace SchwabenCode.QuickIO.Compatibility;

/// <summary>
/// Provides compatibility methods for asynchronous operations in the .NET framework.
/// </summary>
/// <remarks>
/// The <see cref="NETCompatibility"/> class includes a nested <see cref="AsyncExtensions"/> class that 
/// offers static methods to facilitate asynchronous execution of actions and functions, providing a way to 
/// manage asynchronous tasks in a consistent manner.
/// </remarks>
public static class NETCompatibility
{
    /// <summary>
    /// Contains extension methods for executing actions and functions asynchronously.
    /// </summary>
    public static class AsyncExtensions
    {
        /// <summary>
        /// A static instance of <see cref="TaskFactory"/> used for creating and scheduling tasks.
        /// </summary>
        private static readonly TaskFactory s_asyncTaskFactory = Task.Factory;

        /// <summary>
        /// Executes a given action asynchronously and returns a task that completes with a specified result value.
        /// </summary>
        /// <typeparam name="T">The type of the result value.</typeparam>
        /// <param name="action">The action to execute asynchronously.</param>
        /// <param name="resultValue">The result value to return upon successful completion of the action.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static Task ExecuteAsyncResult<T>(Action action, T resultValue)
        {
            TaskCompletionSource<T> tcs = new();

            _ = s_asyncTaskFactory.StartNew(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(resultValue);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Executes a given function asynchronously and returns a task that completes with the function's result.
        /// </summary>
        /// <typeparam name="T">The type of the result produced by the function.</typeparam>
        /// <param name="action">The function to execute asynchronously.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation and containing the function's result.</returns>
        public static Task<T> GetAsyncResult<T>(Func<T> action)
        {
            TaskCompletionSource<T> tcs = new();

            _ = s_asyncTaskFactory.StartNew(() =>
            {
                try
                {
                    tcs.SetResult(action());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }

        /// <summary>
        /// Executes a given action asynchronously and returns a task that represents the operation.
        /// </summary>
        /// <param name="action">The action to execute asynchronously.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static Task ExecuteAsync(Action action)
        {
            return s_asyncTaskFactory.StartNew(action);
        }
    }
}

