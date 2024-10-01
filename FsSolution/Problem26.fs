module Problem26

// Функция для вычисления длины периода десятичной дроби для делителя d
let cycleLength d =
    let rec findCycle rem prevRemainders =
        match rem with
        | 0 -> 0 // Строка 4: Если остаток равен 0, периода нет
        | _ when Map.containsKey rem prevRemainders -> prevRemainders.Count - prevRemainders.[rem] // Строка 6: Найден период, длина цикла
        | _ ->
            let newRem = (rem * 10) % d
            let updatedRemainders = Map.add rem prevRemainders.Count prevRemainders
            findCycle newRem updatedRemainders // Продолжаем искать период

    findCycle 1 Map.empty // Начинаем с остатка 1

// 1. Простая рекурсия с использованием pattern matching
let findMaxCycleRecursively () =
    Seq.init 999 (fun i -> i + 2) // Числа от 2 до 1000
    |> Seq.maxBy cycleLength

// 2. Хвостовая рекурсия с использованием pattern matching и guards
let findMaxCycleTailRecursive () =
    let rec findMax divisor maxDivisor maxLength =
        match divisor with
        | d when d > 1000 -> maxDivisor // Строка 17: если делитель больше 1000, возвращаем максимальный делитель
        | _ ->
            let currentLength = cycleLength divisor

            if currentLength > maxLength then
                findMax (divisor + 1) divisor currentLength // Строка 21: Обновляем максимальную длину цикла
            else
                findMax (divisor + 1) maxDivisor maxLength // Продолжаем с текущим максимальным делителем

    findMax 2 0 0

// 3. Модульное решение с использованием guards
let findMaxCycleModular () =
    let divisors = Seq.init 999 (fun i -> i + 2)
    let cycleLengths = divisors |> Seq.map cycleLength
    Seq.zip divisors cycleLengths |> Seq.maxBy snd |> fst

// 4. С использованием `map` и pattern matching
let findMaxCycleWithMap () =
    Seq.init 999 (fun i -> i + 2)
    |> Seq.map (fun d -> (d, cycleLength d))
    |> Seq.maxBy snd
    |> fst

// 5. Ленивая коллекция (бесконечный список) с использованием guards
let findMaxCycleLazy () =
    Seq.initInfinite ((+) 2)
    |> Seq.take 999
    |> Seq.map (fun d -> (d, cycleLength d))
    |> Seq.maxBy snd
    |> fst
