
[<AutoOpen>]
module ExtensionMethodOnlyInFSharp =
    type System.String with
        member this.IsFSharp() = this = "F#"
        member this.``IsF#`` with get() = this = "F#"

printfn "Equal to F#? %A" ("F#".IsFSharp())
printfn "Equal to F#? %A" ("F#".``IsF#``)

[<AutoOpen>]
module ExtensionMethodForCSharp =
    [<System.Runtime.CompilerServices.ExtensionAttribute>]
    let IsFSharp(str: string) = str = "F#"
    [<System.Runtime.CompilerServices.ExtensionAttribute>]
    let ``IsF#``(str: string) = IsFSharp str


type 'T``[]`` with
    member this.MyExtension with get() = "My Extension"

let x: string array = [||]
x.MyExtension
