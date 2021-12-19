module Shortcuts

open KeyHandler
open TextCopy

let private workPrograms = [
    TogglTrack ;
    Gmail ;
    WindowsTerminal ;
    Spotify ;
    VisualStudioCode ;
    GitHub ;
    Slack ;
]

/// Opens StackOverflow with the clipboard text.
/// If no text is in the current clip, DuckDuckGo is opened instead.
let private HandleLeftKey () =
    match ClipboardService.GetText() with
    | null -> DuckDuckGo
    | rawClip -> 
        match rawClip.Trim() with
        | "" -> DuckDuckGo
        | clip -> StackOverflow clip
    |> start

let private HandleShiftLeftKey () =
    ()

/// Opens all software I need for work.
let private HandleMiddleKey () =
    workPrograms |> Seq.iter start
    ()
    
/// Closes all work related apps after the day is done.
let private HandleShiftMiddleKey () =
    workPrograms |> Seq.iter kill
    ()

let private HandleRightKey () =
    ()
    
let private HandleShiftRightKey () =
    ()

let KeyboardHandler = {
    HandleLeftKeyPress = HandleLeftKey
    HandleMiddleKeyPress = HandleMiddleKey
    HandleRightKeyPress = HandleRightKey
}

let ShiftKeyboardHandler = {
    HandleLeftKeyPress = HandleShiftLeftKey
    HandleMiddleKeyPress = HandleShiftMiddleKey
    HandleRightKeyPress = HandleShiftRightKey
}