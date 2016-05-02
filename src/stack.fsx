// http://stackoverflow.com/questions/36642469/c-patterns-many-conditions

(*
I am looking for a good pattern for my problem.

I have some bool variables:

condition1, condition2,condition3.

Also I have some actions, which are called in different places inside class:

action1,action2,action3

Action1 is called when conditions 1 and 2 are true. action2 is called when conditions 2 and 3 are true. Action 3 is called when all conditions are true.

Of course this is just a simplification of the problem. I don't want to use if else in every place. It is terribly unclear.

I have been thinking about state but I guess it's not best solution for this problem.
*)

let execute c1 c2 c3 =
    match c1, c2, c3 with
    | true, true, false -> "Action1"
    | false, true, true -> "Action2"
    | true, true, true -> "Action3"
    | xyz -> "Skip"

execute true true false     // Action1
execute false true true     // Action2
execute true true true      // Action3
execute false false false   // Skip