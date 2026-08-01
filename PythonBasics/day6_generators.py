"""
Day 6 — Generators: yield แทน return list()
พิสูจน์ lazy evaluation จริงด้วยตา ไม่ใช่แค่เชื่อทฤษฎี
"""
import csv


def load_machines_lazy(filepath):
    with open(filepath, encoding="utf-8-sig") as f:
        reader = csv.DictReader(f)
        for row in reader:
            print(f"  [generator กำลังอ่าน] {row['name']}")
            yield row             # TODO 1: keyword ที่ทำให้ function นี้กลาย เป็น generator (ไม่ใช่ return)


print("1. เรียก function แล้ว...")
machines_gen = load_machines_lazy("machines.csv")
print("2. ผ่านบรรทัดเรียกมาแล้ว — สังเกตว่ายังไม่มี [generator กำลังอ่าน] โผล่มาเลย! ทำไมถึงยังไม่รัน?")

print("3. เริ่มวนลูป ขอแค่ 3 ตัวแรกพอ:")
for i, machine in enumerate(machines_gen):
    print(f"   ได้รับ: {machine['name']}")
    if i >= 2:
        break                      # TODO 2: keyword หยุดลูปทันที (เทียบ break ใน C#)

print("4. สังเกตว่า [generator กำลังอ่าน] โผล่มาแค่ 3 ครั้งเท่านั้น ทั้งที่ machines.csv มี 10 แถว — แถวที่ 4-10 ไม่เคยถูกอ่านเลย")
