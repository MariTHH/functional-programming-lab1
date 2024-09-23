module Problem26

// Функция для вычисления длины периода десятичной дроби для делителя d
let cycleLength d =
    let rec findCycle rem prevRemainders =
        if rem = 0 then 0  // Если остаток равен 0, периода нет
        elif Map.containsKey rem prevRemainders then
            prevRemainders.Count - prevRemainders.[rem]  // Найден период, длина цикла
        else
            let newRem = (rem * 10) % d
            let updatedRemainders = Map.add rem prevRemainders.Count prevRemainders
            findCycle newRem updatedRemainders
    findCycle 1 Map.empty  // Начинаем с остатка 1

// 1. Простая рекурсия
let findMaxCycleRecursively () =
    Seq.init 999 (fun i -> i + 2)  // Числа от 2 до 1000
    |> Seq.maxBy cycleLength

// 2. Хвостовая рекурсия
let findMaxCycleTailRecursive () =
    let rec findMax divisor maxDivisor maxLength =
        if divisor > 1000 then maxDivisor
        else
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
