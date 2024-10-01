module ProblemTests

open Xunit
open Problem7
open Problem26

[<Fact>]
let ``10001-е простое число (рекурсия)``() =
    Assert.Equal(104743, findPrimeRecursively 10001)

[<Fact>]
let ``10001-е простое число (хвостовая рекурсия)``() =
    Assert.Equal(104743, findPrimeTailRecursive 10001)

[<Fact>]
let ``Число с самым длинным периодом дроби (рекурсия)``() =
    Assert.Equal(983, findMaxCycleRecursively ())

[<Fact>]
let ``Число с самым длинным периодом дроби (модульное решение)``() =
    Assert.Equal(983, findMaxCycleModular ())
