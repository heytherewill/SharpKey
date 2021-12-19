module KeyHandler

type KeyHandler = unit -> unit
type KeyboardHandler = {
    HandleLeftKeyPress: KeyHandler
    HandleMiddleKeyPress: KeyHandler
    HandleRightKeyPress: KeyHandler
}
