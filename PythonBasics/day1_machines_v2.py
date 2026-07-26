# Python Day 1 — Exercise L2 (Independent, no skeleton)
# โจทย์:
# 1. เขียน function ชื่อ get_unreliable_machines(machines_list)
#    - loop ผ่านเครื่องจักรทุกเครื่อง เช็ค issue_count > 3
#    - เก็บชื่อเครื่องที่เข้าเงื่อนไขใส่ list ว่าง แล้ว return list นั้นออกมา
# 2. นอกฟังก์ชัน: เรียกใช้ function เก็บผลลัพธ์ใส่ตัวแปร แล้ว loop print ผลลัพธ์เอง
#
# รันด้วย: python day1_machines_v2.py


machines = [
    {"name": "เครื่องอัดยาง B2", "issue_count": 5},
    {"name": "เครื่องตัด C3", "issue_count": 2},
    {"name": "เครื่องผสม A1", "issue_count": 4},
    {"name": "เครื่องบรรจุ D4", "issue_count": 1},
]

# เขียนเองจากตรงนี้
def get_unreliable_machines(machines_list):     
    results = []  # สร้าง list ว่างเก็บชื่อเครื่องจักรที่เสียบ่อย
    for machine in machines_list:             # loop ผ่าน parameter ที่รับเข้ามา (ไม่ใช่ machines ตรงๆ)
        if machine["issue_count"] > 3:     # เงื่อนไขให้แล้ว — machine["key"] คือวิธีดึงค่าจาก dict
            results.append(machine["name"])  # เก็บชื่อเครื่องจักรที่เข้าเงื่อนไขลง list
    return results  # return list ชื่อเครื่องจักรที่เสียบ่อย

result = get_unreliable_machines(machines)
for machine_name in result:
    print(machine_name) # print ชื่อเครื่องจักรที่เสียบ่อย
