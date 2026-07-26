# Python Day 1 — Exercise L1 (Guided)
# โจทย์: หาเครื่องจักรที่เสียบ่อย (issue_count > 3) แล้ว print ชื่อออกมา
# เทียบกับ Machine Reliability Report ที่เพิ่งทำใน C# (GroupJoin) — โจทย์เดียวกัน คนละภาษา
#
# เติม ??? ให้ครบ แล้วรันด้วย: python day1_machines.py

machines = [
    {"name": "เครื่องอัดยาง B2", "issue_count": 5},
    {"name": "เครื่องตัด C3", "issue_count": 2},
    {"name": "เครื่องผสม A1", "issue_count": 4},
    {"name": "เครื่องบรรจุ D4", "issue_count": 1},
]

# TODO 1: ตั้งชื่อ function + parameter รับ list เครื่องจักรเข้ามา
def find_unreliable_machines(machines_list):
    for machine in machines_list:             # TODO 2: loop ผ่าน parameter ที่รับเข้ามา (ไม่ใช่ machines ตรงๆ)
        if machine["issue_count"] > 3:     # เงื่อนไขให้แล้ว — machine["key"] คือวิธีดึงค่าจาก dict
            print(machine["name"])              # TODO 3: print ชื่อเครื่อง (key คือ "name")


find_unreliable_machines (machines)   # TODO 4: เรียกใช้ function ที่สร้างไว้ ส่ง machines เข้าไป
