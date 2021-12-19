module KeyHandler

open System.Diagnostics

type KeyHandler = unit -> unit
type KeyboardHandler = {
    HandleLeftKeyPress: KeyHandler
    HandleMiddleKeyPress: KeyHandler
    HandleRightKeyPress: KeyHandler
}

type Program =
| WindowsTerminal
| Slack
| Spotify
| VisualStudioCode
| GitHub
| Firefox of string

let Gmail = Firefox "https://gmail.com"
let DuckDuckGo = Firefox "https://duckduckgo.com"
let TogglTrack = Firefox "https://track.toggl.com/"
let StackOverflow query = Firefox ("https://stackoverflow.com/search?q=" + query)

let start (program: Program) =
    use proc = new Process()
    proc.StartInfo.FileName <- 
        match program with
        | WindowsTerminal -> "wt"
        | Slack -> "slack://app"
        | Spotify -> "spotify"
        | VisualStudioCode -> "code"
        | GitHub -> "github"
        | Firefox url -> url
        
    proc.StartInfo.UseShellExecute <- 
        match program with
        | Firefox _ -> true
        | _ -> false

    proc.Start() |> ignore
    
let kill (program: Program) =
    let processName = 
        match program with
        | WindowsTerminal -> "WindowsTerminal"
        | Slack -> "slack"
        | Spotify -> "spotify"
        | GitHub -> "GitHubDesktop"
        | VisualStudioCode -> "code"
        | Firefox _ -> "firefox"

    Process.GetProcessesByName(processName)
    |> Seq.iter (fun proc -> proc.Kill())