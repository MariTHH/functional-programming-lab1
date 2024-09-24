
## Лабораторная работа №1 по F#

## Задачи Эйлера №7 и №26

### Цель

Цель лабораторной работы — освоить базовые приёмы и абстракции функционального программирования в F# на примере решения задач проекта Эйлер. В рамках работы необходимо решить две задачи с использованием различных техник программирования:

- Простой рекурсии
- Хвостовой рекурсии
- Модульной реализации (генерация, фильтрация, свёртка)
- Использования функции `map`
- Работы с ленивыми коллекциями и бесконечными списками

---

### Описание задач

1. **Задача №7**: Найти 10001-е простое число.
2. **Задача №26**: Найти число `d < 1000`, для которого десятичная дробь \(1/d\) имеет самую длинную повторяющуюся последовательность.

---

## Задача №7: Найти 10001-е простое число

### Постановка задачи

Необходимо найти 10001-е простое число, используя различные методы функционального программирования.

### Решения

#### 1. Простая рекурсия

```fsharp
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

```

##### Описание: 

Простая рекурсия использует два вложенных рекурсивных вызова: один для проверки простоты числа (isPrime), второй для поиска нужного простого числа. Функция возвращает результат, когда найдено 10001-е простое число.

- доп: 
Здесь у меня возникло предложение оптимизировать за счет пропуска простых четных чисел.

```fsharp
let findPrimeRecursively count =
    let rec findPrimeInner count n =
        if count = 0 then n - 1
        else if isPrime n then findPrimeInner (count - 1) (n + (if n = 2 then 1 else 2))
        else findPrimeInner count (n + (if n = 2 then 1 else 2))
    findPrimeInner count 2
```

#### 2. Хвостовая рекурсия

```fsharp
let findPrimeTailRecursive count =
    let rec findPrimeInner count n accumulator =
        if count = 0 then accumulator
        else if isPrime n then findPrimeInner (count - 1) (n + 1) n
        else findPrimeInner count (n + 1) accumulator
    findPrimeInner count 2 0

```

##### Описание: 

Хвостовая рекурсия сохраняет состояние на каждом шаге и передает его дальше, избавляясь от необходимости хранить стек вызовов.

#### 3. Модульное решение

```fsharp
let findPrimeModular count =
    Seq.initInfinite ((+) 2)
    |> Seq.filter isPrime
    |> Seq.item (count - 1)

```

##### Описание: 

Бесконечная последовательность генерируется с использованием `Seq.initInfinite`, фильтруется по признаку простоты, и отбирается нужное по порядку простое число.

#### 4. Использование `map`

```fsharp
let findPrimeWithMap count =
    Seq.initInfinite ((+) 2)
    |> Seq.map (fun n -> if isPrime n then Some n else None)
    |> Seq.choose id
    |> Seq.item (count - 1)
    
```

##### Описание: 

Используя `map` и `choose`, мы фильтруем только простые числа и создаем последовательность, отбирая нужное по порядку число.

#### 5. Ленивая коллекция

```fsharp
let findPrimeLazy count =
    Seq.initInfinite ((+) 2)
    |> Seq.filter isPrime
    |> Seq.cache
    |> Seq.item (count - 1)

```

##### Описание: 

Использование ленивой последовательности с кэшированием позволяет эффективно обрабатывать поток данных.

### решение на Python

```python
def is_prime(n):
    if n < 2:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0:
            return False
    return True

def find_nth_prime(n):
    count = 0
    num = 1
    while count < n:
        num += 1
        if is_prime(num):
            count += 1
    return num

result = find_nth_prime(10001)
print(result)  
```

## Задача №26: Найти число с самой длинной повторяющейся десятичной дробью

### Постановка задачи

Необходимо найти число 𝑑<1000, для которого десятичная дробь 1/𝑑 имеет самую длинную повторяющуюся последовательность.

### Решения

#### 1. Простая рекурсия

```fsharp
let findMaxCycleRecursively () =
    Seq.init 999 (fun i -> i + 2)
    |> Seq.maxBy cycleLength

```

##### Описание: 

 Используется простая рекурсия для вычисления длины периода для каждого 𝑑 и нахождения числа с максимальной длиной.

#### 2. Хвостовая рекурсия

```fsharp
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

```

##### Описание: 

Используется хвостовая рекурсия для итерации по всем делителям 𝑑, сохраняя максимальную длину периода.

#### 3. Модульное решение

```fsharp
let findMaxCycleModular () =
    let divisors = Seq.init 999 (fun i -> i + 2)
    let cycleLengths = divisors |> Seq.map cycleLength
    Seq.zip divisors cycleLengths |> Seq.maxBy snd |> fst

```

##### Описание: 

Генерация последовательности делителей и вычисление длин их циклов с использованием маппинга и фильтрации.

#### 4. Использование `map`

```fsharp
let findMaxCycleWithMap () =
    Seq.init 999 (fun i -> i + 2)
    |> Seq.map (fun d -> (d, cycleLength d))
    |> Seq.maxBy snd
    |> fst

```

##### Описание: 

С помощью `map` создается последовательность пар (𝑑,длинапериода), после чего находится максимальная длина.

#### 5. Ленивая коллекция

```fsharp
let findMaxCycleLazy () =
    Seq.initInfinite ((+) 2)
    |> Seq.take 999
    |> Seq.map (fun d -> (d, cycleLength d))
    |> Seq.maxBy snd
    |> fst

```

##### Описание: 

Использование ленивой коллекции для работы с бесконечными последовательностями и выборки максимального значения.

### решение на Python

```python
def cycle_length(d):
    remainders = {}
    remainder = 1 % d
    position = 0
    
    while remainder != 0 and remainder not in remainders:
        remainders[remainder] = position
        remainder = (remainder * 10) % d
        position += 1
    
    if remainder == 0:
        return 0  # Нет повторяющейся дроби
    else:
        return position - remainders[remainder]  # Длина цикла

def find_max_cycle(limit):
    max_length = 0
    max_d = 0
    
    for d in range(2, limit):
        length = cycle_length(d)
        if length > max_length:
            max_length = length
            max_d = d
    
    return max_d

result = find_max_cycle(1000)
print(result) 
```

## Выводы

`Ответы: на 7 задачу 104743; на 26 задачу 983`

Я ознакомилась с языком F#, узнала его синтаксис, операторы и функции. Синтаксис и разные операторы немного непривычны для меня, но это оказалось несложно освоить. Эта лабораторная работа позволила мне увидеть, как функциональное программирование может быть использовано для решения сложных задач. Я сделала небольшие выводы, пока делала реализации решений:

Например, простая рекурсия удобна для базовых решений, а модульное решение делает код более структурированным. Попробовала также для решения задач метода как хвостовую рекурсию, использование `map` и ленивые коллекции.
