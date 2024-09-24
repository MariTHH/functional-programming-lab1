module Problem7

// 1. Простая рекурсия
let isPrime n =
    let rec check i =
        i * i > n || (n % i <> 0 && check (i + 1))
    check 2

let findPrimeRecursively count =
    let rec findPrimeInner count n =
        if count = 0 then n - 1
        else if isPrime n then findPrimeInner (count - 1) (n + 1)
        else findPrimeInner count (n + 1)
    findPrimeInner count 2

// 2. Хвостовая рекурсия

let findPrimeTailRecursive count =
    let rec findPrimeInner foundPrimes currNum =
        if foundPrimes = count then currNum - 1
        else if isPrime currNum then findPrimeInner (foundPrimes + 1) (currNum + 1)
        else findPrimeInner foundPrimes (currNum + 1)
    
    // Начинаем поиск с 2 (первое простое число) и с нуля найденных простых чисел
    findPrimeInner 0 2

// 3. Модульное решение
let findPrimeModular count =
    Seq.initInfinite ((+) 2)
    |> Seq.filter isPrime
    |> Seq.item (count - 1)

// 4. С использованием `map`
let findPrimeWithMap count =
    Seq.initInfinite ((+) 2)
    |> Seq.map (fun n -> if isPrime n then Some n else None)
    |> Seq.choose id
    |> Seq.item (count - 1)

// 5. Ленивая коллекция (бесконечный список)
let findPrimeLazy count =
    Seq.initInfinite ((+) 2)
    |> Seq.filter isPrime
    |> Seq.cache
    |> Seq.item (count - 1)
