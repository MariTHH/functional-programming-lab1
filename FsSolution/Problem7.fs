module Problem7

// 1. Простая рекурсия с использованием pattern matching и guards
let isPrime n =
    let rec check i =
        match i with
        | _ when i * i > n -> true
        | _ when n % i = 0 -> false
        | _ -> check (i + 1)

    check 2

let findPrimeRecursively count =
    let rec findPrimeInner count n =
        match count with
        | 0 -> n - 1
        | _ when isPrime n -> findPrimeInner (count - 1) (n + 1)
        | _ -> findPrimeInner count (n + 1)

    findPrimeInner count 2

// 2. Хвостовая рекурсия с использованием pattern matching и guards
let findPrimeTailRecursive count =
    let rec findPrimeInner foundPrimes currNum =
        match foundPrimes with
        | _ when foundPrimes = count -> currNum - 1
        | _ when isPrime currNum -> findPrimeInner (foundPrimes + 1) (currNum + 1)
        | _ -> findPrimeInner foundPrimes (currNum + 1)

    findPrimeInner 0 2

// 3. Модульное решение с использованием guards
let findPrimeModular count =
    Seq.initInfinite ((+) 2) |> Seq.filter isPrime |> Seq.item (count - 1)

// 4. С использованием `map` и pattern matching
let findPrimeWithMap count =
    Seq.initInfinite ((+) 2)
    |> Seq.map (fun n ->
        match isPrime n with
        | true -> Some n
        | false -> None)
    |> Seq.choose id
    |> Seq.item (count - 1)

// 5. Ленивая коллекция (бесконечный список) с использованием guards
let findPrimeLazy count =
    Seq.initInfinite ((+) 2)
    |> Seq.filter (fun n ->
        match isPrime n with
        | true -> true
        | false -> false)
    |> Seq.cache
    |> Seq.item (count - 1)
