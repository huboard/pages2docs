module pages2docs.tests

open Xunit

let add x y = x + y // unit

[<Fact>]   // test
let hello_test_world() =

    Assert.Equal(2, 2)