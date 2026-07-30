import csv

from day3_csv_reading import load_machines_from_csv, machines_report


def save_report_to_csv(result, filepath):
    with open(filepath,"w", encoding="utf-8-sig" ) as f:                          # TODO 1: mode สำหรับ "เขียน" ไฟล์ (ตัวอักษรเดียว)
        writer = csv.DictWriter (f, fieldnames=["name", "status"])   # TODO 2: DictWriter เรียกยังไง (คู่กับ DictReader ที่ใช้เมื่อวาน)
        writer.writeheader()                                          # TODO 3: เขียน header row ก่อนข้อมูล ใช้ method ไหน
        for name in result["reliable"]:
            writer.writerow({"name": name, "status": "Reliable"})
        for name in result["unreliable"]:
            writer.writerow({"name": name, "status": "Unreliable"})     # TODO 4: เติมให้ครบเหมือน pattern บรรทัดบน


machines = load_machines_from_csv("machines.csv")
result = machines_report(machines)
save_report_to_csv(result, "machines_report_output.csv")
print("Report saved ✅")