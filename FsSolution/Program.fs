module Program

open System
open Problem7
open Problem26

[<EntryPoint>]
let main argv =
    printfn "Выберите задачу для запуска:"
    printfn "1 - 10001-е простое число"
    printfn "2 - Длина периода десятичной дроби"

    let choice = Console.ReadLine()

    match choice with
    | "1" ->
        printfn "10001-е простое число (рекурсия): %d" (findPrimeRecursively 10001)
        printfn "10001-е простое число (хвостовая рекурсия): %d" (findPrimeTailRecursive 10001)
        printfn "10001-е простое число (модульное решение): %d" (findPrimeModular 10001)
        printfn "10001-е простое число (с использованием map): %d" (findPrimeWithMap 10001)
        printfn "10001-е простое число (ленивая коллекция): %d" (findPrimeLazy 10001)
    | "2" ->
        printfn "Число с самым длинным периодом дроби (рекурсия): %d" (findMaxCycleRecursively ())
        printfn "Число с самым длинным периодом дроби (хвостовая рекурсия): %d" (findMaxCycleTailRecursive ())
        printfn "Число с самым длинным периодом дроби (модульное решение): %d" (findMaxCycleModular ())
        printfn "Число с самым длинным периодом дроби (с использованием map): %d" (findMaxCycleWithMap ())
        printfn "Число с самым длинным периодом дроби (ленивая коллекция): %d" (findMaxCycleLazy ())
    | _ -> printfn "Неправильный выбор"

    0
