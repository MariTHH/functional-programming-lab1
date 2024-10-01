namespace FsSolution.Tests

open NUnit.Framework
open Problem7
open Problem26

[<TestFixture>]
type PrimeTests() =

    [<Test>]
    member _.TestFindPrimeRecursively() =
        let expected = 104743
        let result = findPrimeRecursively 10001
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindPrimeTailRecursive() =
        let expected = 104743
        let result = findPrimeTailRecursive 10001
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindPrimeModular() =
        let expected = 104743
        let result = findPrimeModular 10001
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindPrimeWithMap() =
        let expected = 104743
        let result = findPrimeWithMap 10001
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindPrimeLazy() =
        let expected = 104743
        let result = findPrimeLazy 10001
        Assert.AreEqual(expected, result)

[<TestFixture>]
type CycleLengthTests() =

    [<Test>]
    member _.TestFindMaxCycleRecursively() =
        let expected = 983
        let result = findMaxCycleRecursively ()
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindMaxCycleTailRecursive() =
        let expected = 983
        let result = findMaxCycleTailRecursive ()
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindMaxCycleModular() =
        let expected = 983
        let result = findMaxCycleModular ()
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindMaxCycleWithMap() =
        let expected = 983
        let result = findMaxCycleWithMap ()
        Assert.AreEqual(expected, result)

    [<Test>]
    member _.TestFindMaxCycleLazy() =
        let expected = 983
        let result = findMaxCycleLazy ()
        Assert.AreEqual(expected, result)
