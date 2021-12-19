module Shortcuts

let private HandleLeftKey () =
    ()

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