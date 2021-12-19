namespace SharpKey

open SharpHook
open SharpHook.Native
open Shortcuts
open System.Threading
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open System

type Worker(logger: ILogger<Worker>) =
    inherit BackgroundService()

    let mutable currentHandler = KeyboardHandler
    
    let onKeyPressed (keyboardHookEventArgs: KeyboardHookEventArgs) =
        match keyboardHookEventArgs.Data.KeyCode with
        | KeyCode.VcLeftShift -> currentHandler <- ShiftKeyboardHandler
        | KeyCode.VcF17 -> currentHandler.HandleLeftKeyPress ()
        | KeyCode.VcF18 -> currentHandler.HandleMiddleKeyPress ()
        | KeyCode.VcF19 -> currentHandler.HandleRightKeyPress ()
        | _ -> ()

    let onKeyReleased (keyboardHookEventArgs: KeyboardHookEventArgs) = 
        if keyboardHookEventArgs.Data.KeyCode = KeyCode.VcLeftShift then 
            currentHandler <- KeyboardHandler

    override _.ExecuteAsync(cancellationToken: CancellationToken) =
        let hook = new TaskPoolGlobalHook()
        hook.KeyPressed.Add(onKeyPressed)
        hook.KeyReleased.Add(onKeyReleased)
        cancellationToken.Register(Action hook.Dispose) |> ignore
        hook.Start()