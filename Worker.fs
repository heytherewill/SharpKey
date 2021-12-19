namespace SharpKey

open SharpHook
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open System

type Worker(logger: ILogger<Worker>) =
    inherit BackgroundService()

    override _.ExecuteAsync(cancellationToken: CancellationToken) =
        let hook = new TaskPoolGlobalHook()
        hook.Start()