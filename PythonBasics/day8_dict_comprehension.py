from platform import machine


machines = [
    {"name": "Machine A", "issues": 2},
    {"name": "Machine B", "issues": 6},
    {"name": "Machine C", "issues": 8},
    {"name": "Machine D", "issues": 1},
    {"name": "Machine E", "issues": 5}
]

# สร้าง dict: ชื่อเครื่อง -> จำนวนปัญหา
machine_lookup = {machine["name"]: machine["issues"] for machine in machines}

print(machine_lookup)  # Output: {'Machine A': 2, 'Machine B': 6, 'Machine C': 8, 'Machine D': 1}
print(machine_lookup["Machine C"])  # Output: 6

# Dict Comprehension 
def unreliable_machine_lookup(machines_list, threshold = 5): 
    return {machine["name"]: machine["issues"]
            for machine in machines_list 
            if machine["issues"] >= threshold} 
print(unreliable_machine_lookup(machines))  # Output: {'Machine B': 6, 'Machine C': 8, 'Machine E': 5}