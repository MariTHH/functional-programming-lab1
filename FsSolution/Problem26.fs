module Problem26

// Функция для вычисления длины периода десятичной дроби для делителя d
let cycleLength d =
    let rec findCycle rem prevRemainders =
        match rem with
        | 0 -> 0
        | _ when Map.containsKey rem prevRemainders -> prevRemainders.Count - prevRemainders.[rem] // Строка 6: Найден период, длина цикла
        | _ ->
            let newRem = (rem * 10) % d
            let updatedRemainders = Map.add rem prevRemainders.Count prevRemainders
            findCycle newRem updatedRemainders

    findCycle 1 Map.empty

// 1. Простая рекурсия
let findMaxCycleRecursively () =
    Seq.init 999 (fun i -> i + 2) |> Seq.maxBy cycleLength

// 2. Хвостовая рекурсия
let findMaxCycleTailRecursive () =
    let rec findMax divisor maxDivisor maxLength =
        match divisor with
        | d when d > 1000 -> maxDivisor
        | _ ->
            let currentLength = cycleLength divisor

            if currentLength > maxLength then
                findMax (divisor + 1) divisor currentLength
            else
                findMax (divisor + 1) maxDivisor maxLength

    findMax 2 0 0

// 3. Модульное решение
let findMaxCycleModular () =
    let divisors = Seq.init 999 (fun i -> i + 2)
    let cycleLengths = divisors |> Seq.map cycleLength
    Seq.zip divisors cycleLengths |> Seq.maxBy snd |> fst

// 4. С использованием `map`
let findMaxCycleWithMap () =
    Seq.init 999 (fun i -> i + 2)
    |> Seq.map (fun d -> (d, cycleLength d))
    |> Seq.maxBy snd
    |> fst

// 5. Ленивая коллекция (бесконечный список)
let findMaxCycleLazy () =
    Seq.initInfinite ((+) 2)
    |> Seq.take 999
    |> Seq.map (fun d -> (d, cycleLength d))
    |> Seq.maxBy snd
    |> fst
