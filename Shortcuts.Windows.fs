module Shortcuts

open KeyHandler
open TextCopy
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

let private HandleMiddleKey () =
    ()
    
let private HandleShiftMiddleKey () =
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