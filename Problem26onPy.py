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
