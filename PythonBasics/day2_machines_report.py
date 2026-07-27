machines = [
    {"name": "เครื่องอัดยาง B2", "issue_count": 5},
    {"name": "เครื่องตัด C3", "issue_count": 2},
    {"name": "เครื่องผสม A1", "issue_count": 4},
    {"name": "เครื่องบรรจุ D4", "issue_count": 1},
    {"name": "เครื่องส่งสายพาน A1" ,"issue_count":3},
    {"name": "เครื่องหลอมยาง E5", "issue_count": 6},
    {"name": "เครื่องพิมพ์ลาย F6", "issue_count": 0},
    {"name": "เครื่องตรวจสอบคุณภาพ G7", "issue_count": 3},
    {"name": "เครื่องเป่าลม H8", "issue_count": 7},
    {"name": "เครื่องแพ็คสินค้า I9", "issue_count": 2},
]

def machines_report(machines_list, threshold=3):        # TODO 1: threshold ต้องมาจาก parameter
    reliable = []                                          # TODO 2: list ว่างสำหรับเครื่องที่ไม่ค่อยเสีย
    unreliable = []
    for machine in machines_list:
        if machine["issue_count"] > threshold:
            unreliable.append(machine["name"])
        else:
            reliable.append(machine["name"])                     # TODO 3: เงื่อนไขนี้เข้ากลุ่มไหน?
    return {"reliable": reliable, "reliable_count": len(reliable),
            "unreliable": unreliable, "unreliable_count": len(unreliable)}   # TODO 4

result_default = machines_report(machines)
result_2 = machines_report(machines, threshold=1)          # TODO 5: ลองค่าต่ำกว่า default

#edge case: threshold = 100
result_edge = machines_report(machines, threshold=100)
print("Threshold=100 unreliable_count:", result_edge["unreliable_count"])

print(f"Unreliable machines ({result_default['unreliable_count']}):")
for name in result_default["unreliable"]:
    print(f" - {name}")


print(f"Reliable machines ({result_default['reliable_count']}):")
for name in result_default["reliable"]:
    print(f" - {name}")


