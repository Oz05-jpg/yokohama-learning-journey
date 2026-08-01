import csv

def load_machines_from_csv(filepath):
    with open(filepath, encoding="utf-8-sig") as f:
        reader = csv.DictReader(f)
        for row in reader:
            print(f"  [generator กำลังอ่าน] {row['name']}")
            yield row             # TODO 1: keyword ที่ทำให้ function นี้กลาย เป็น generator (ไม่ใช่ return)

def find_high_issue_machines(filepath, min_issues=5):
    machines_gen = load_machines_from_csv(filepath)
    for machine in machines_gen:
        if int(machine['issue_count']) >= min_issues:
            yield machine     # TODO 2: keyword ที่ทำให้ function นี้กลาย เป็น generator (ไม่ใช่ return)

for m in find_high_issue_machines("machines.csv", 5):
    print(f"   ได้รับ: {m['name']} มี issue_count = {m['issue_count']}")
    