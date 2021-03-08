using System.Threading;

namespace GISharp.Lib.GLib
{
    partial class MainContext
    {
        /// <summary>
        /// .NET synchronization context for a GLib <see cref="MainContext"/>
        /// </summary>
        class GSynchronizationContext : SynchronizationContext
        {
            readonly MainContext context;

            public GSynchronizationContext(MainContext context)
            {
                this.context = context;
            }

            /// <inheritdoc/>
            public override SynchronizationContext CreateCopy()
            {
                return new GSynchronizationContext(context);
            }

            /// <inheritdoc/>
            public override void Post(SendOrPostCallback d, object? state)
            {
                using var source = IdleSource.New();
                source.SetCallback(() => {
                    d.Invoke(state);
                    return Source.Remove;
                });
                source.Attach(context);
            }

            public override void Send(SendOrPostCallback d, object? state)
            {
                context.Invoke(() => {
                    d.Invoke(state);
                    return Source.Remove;
                });
            }
        }

        /// <summary>
        /// Gets the .NET synchronization context for this context.
        /// </summary>
        /// <value>The synchronization context.</value>
        /// <remarks>
        /// This is used to integrate with .NET async.
        ///
        /// SynchronizationContext.SetSynchronizationContext (MainContext.Default.SynchronizationContext);
        ///
        /// ...should be called once at the begining of a program so that async
        /// function callbacks will run in the default GLib main context.
        /// </remarks>
        public SynchronizationContext SynchronizationContext {
            get {
                if (_SynchronizationContext is null) {
                    _SynchronizationContext = new(this);
                }
                return _SynchronizationContext;
            }
        }
        GSynchronizationContext? _SynchronizationContext;
    }
}
