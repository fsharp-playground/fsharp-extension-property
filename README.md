## Extension Method / Property

### เขียน Extension method เพิ่มใช้งานใน `F#`

```fsharp
[<AutoOpen>]
module ExtensionMethodOnlyInFSharp =
    type System.String with
        member this.IsFSharp() = this = "F#"
        member this.``IsF#`` with get() = this = "F#"

printfn "Equal to F#? %A" ("F#".IsFSharp())
printfn "Equal to F#? %A" ("F#".``IsF#``)
```

- สร้างสร้าง Extension method / property ของ `String` โดยใช้ Keyword `with`
- `IsFSharp()` เป็น Extension method เรียกใช้ผ่าน `.IsFSharp()`
- `IsF#` เป็น  Extension property เรียกใช้ผ่าน `.IsF#` โดยไม่ต้องเติม `()`

### เขียน Extension method ให้สามารถเรียกใช้งานจาก `C#`

```fsharp
[<AutoOpen>]
module ExtensionMethodForCSharp =
    [<System.Runtime.CompilerServices.ExtensionAttribute>]
    let IsFSharp(str: string) = str = "F#"
    [<System.Runtime.CompilerServices.ExtensionAttribute>]
    let ``IsF#``(str: string) = IsFSharp str
```

 - ต้องเพิ่ม `[<System.Runtime.CompilerServices.ExtensionAttribute>]`
 - Extension property `IsF#` ไม่สามารถเรียกใช้งานจาก `C#` ได้

### Extension method ใน Array

```fsharp
type 'T``[]`` with
    member this.MyExtension with get() = "My Extension"

let x: string array = [||]
x.MyExtension
```

### Extension property กับ Literal type

```fsharp
type System.Int32 with
  member x.Months = DateTime.Today.AddMonths(x) - DateTime.Today
  member x.Years = DateTime.Today.AddYears(x) - DateTime.Today

type System.Double with
  member x.Days = DateTime.Today.AddDays(x) - DateTime.Today

type System.TimeSpan with
  member x.Ago = DateTime.Now.Add(-x)
  member x.FromNow = DateTime.Now.Add(x)
  member x.FromToday = DateTime.Today.Add(x)

let _20YearAgo = DateTime.Now - 20 .Years
let _50YearAgo = 50 .Years.Ago
let _100YearFromNow = DateTime.Now + 100 .Years
```

- สามารถใช้ `Space .<ExtensionProperty>` แทน `().<ExtensionProperty>`
- เช่น ใช้ `100 .Years` แทน `(100).Years`

## Link

- http://blog.stermon.com/articles/2014/03/06/fsharp-surprisingly-expressive
- http://apollo13cn.blogspot.com/2012/08/f-extension-methods.html