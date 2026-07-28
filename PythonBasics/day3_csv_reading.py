import csv


def load_machines_from_csv(filepath):
    machines_list = []
    with open(filepath, "r", encoding="utf-8") as f:   # TODO 1: mode สำหรับ "อ่าน" ไฟล์ (ตัวอักษรเดียว)
        reader = csv.DictReader(f)                             # TODO 2: reader แบบไหนให้แต่ละแถวเป็น dict (key = ชื่อ column)
        for row in reader:
            machines_list.append({
                "name": row["name"],
                "issue_count": int(row["issue_count"])  # TODO 3: CSV อ่านมาเป็น string เสมอ ต้องแปลงเป็นอะไรก่อนเทียบเลข
            })
    return machines_list


def machines_report(machines_list, threshold=3):
    reliable = []
    unreliable = []
    for machine in machines_list:
        if machine["issue_count"] > threshold:
            unreliable.append(machine["name"])
        else:
            reliable.append(machine["name"])
    return {"reliable": reliable, "reliable_count": len(reliable),
            "unreliable": unreliable, "unreliable_count": len(unreliable)}


machines = load_machines_from_csv("machines.csv")
result = machines_report(machines)   # TODO 4: เรียกด้วย argument ตัวไหน (ตัวแปรที่เพิ่งโหลดมา)

print(f"Unreliable machines ({result['unreliable_count']}):")
for name in result["unreliable"]:
    print(f" - {name}")

print(f"Reliable machines ({result['reliable_count']}):")
for name in result["reliable"]:
    print(f" - {name}")
