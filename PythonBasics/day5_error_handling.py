"""
Day 5 — Error Handling: เทียบกับ C# try/catch (2026-06-03)
คำถาม: ถ้า machines.csv ไม่มีอยู่จริง โปรแกรมควรทำยังไง?
"""
import csv


def load_machines_from_csv(filepath):
    try:
        with open(filepath, encoding="utf-8-sig") as f:
            reader = csv.DictReader(f)
            return list(reader)
    except FileNotFoundError:               # TODO 1: exception type ตอนเปิดไฟล์ที่ไม่มีอยู่จริง (ชื่อสะกดตรงตัวความหมายเลย)
        print(f"⚠️ ไม่เจอไฟล์ {filepath}")
        return []                            # TODO 2: คืนอะไรแทน crash (เทียบ AC ที่เคยเขียนใน ticket C#: "ไม่มีข้อมูล → คืน empty list ไม่ใช่ error")


# ทดสอบ 2 เคส — ห้ามลบ ใช้เช็คว่า TODO ถูกทั้งคู่
print("เคส 1: ไฟล์ไม่มีจริง ->", load_machines_from_csv("machines_typo.csv"))
print("เคส 2: ไฟล์มีจริง ->", load_machines_from_csv("machines.csv"))
