import csv
import models #from model หมายถึงการนำเข้าคลาส Technician จากไฟล์ models.py คล้ายการ import module ในภาษาอื่น ๆ

#load technicians from CSV file
def load_technicians_from_csv(filepath):
    technicians_list = []
    with open(filepath, "r", encoding="utf-8") as f:
        reader = csv.DictReader(f)
        for row in reader:
            technicians_list.append(models.Technician(
                name=row["FullName"],
                specialty=row["specialty"]
            ))
    return technicians_list

#list comprehension to filter technicians by specialty
def filter_technicians_by_specialty(technicians_list, target_specialty):
    return [tech for tech in technicians_list if tech.matches_specialization(target_specialty)] 

#output technicians by specialty
print("=== Load technicians from CSV ===")
technicians = load_technicians_from_csv("technicians.csv")
print("ใครเป็น Electrical Technician:" , [tech.name for tech in 
filter_technicians_by_specialty(technicians, "Electrical")])

