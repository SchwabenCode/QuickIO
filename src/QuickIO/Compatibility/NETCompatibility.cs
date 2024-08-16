namespace SchwabenCode.QuickIO.Compatibility;

public static class NETCompatibility
{
    /// <summary>
    /// Several methods for async operations
    /// </summary>
    public static class AsyncExtensions
    {
        private static readonly TaskFactory s_asyncTaskFactory = Task.Factory;

        /// <summary>
        /// Executes the action in a wrapped task to use async operation
        /// </summary>
        /// <typeparam name="T">Result Type</typeparam>
        /// <param name="action">Action to execute in wrapped task</param>
        /// <param name="resultValue">Returns this value if finished</param>
        /// <returns><see cref="Task"/></returns>
        public static Task ExecuteAsyncResult<T>(Action action, T resultValue)
        {
            TaskCompletionSource<T> tcs = new( );

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
        /// Executes the action in a wrapped task to use async operation and gets the result
        /// </summary>
        /// <typeparam name="T">Result Type</typeparam>
        /// <param name="action">Action to execute in wrapped task</param>
        /// <returns><see cref="Task"/> with result value</returns>
        public static Task<T> GetAsyncResult<T>(Func<T> action)
        {
            TaskCompletionSource<T> tcs = new( );

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
        /// Executes the action in a wrapped task to use async operation
        /// </summary>
        /// <param name="action">Action to execute in wrapped task</param>
        /// <returns><see cref="Task"/></returns>
        public static Task ExecuteAsync(Action action)
        {
            return s_asyncTaskFactory.StartNew(action);
        }
    }
}
