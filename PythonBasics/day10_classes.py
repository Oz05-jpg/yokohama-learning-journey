import csv

# load technicians from CSV file
def load_technicians_from_csv(filepath):
    technicians_list = []
    with open(filepath, "r", encoding="utf-8") as f:
        reader = csv.DictReader(f)
        for row in reader:
            technicians_list.append(Technician(
                name=row["FullName"],
                specialty=row["specialty"]
            ))
    return technicians_list

#list comprehension to filter technicians by specialty
def filter_technicians_by_specialty(technicians_list, target_specialty):
    return [tech for tech in technicians_list if tech.matches_specialization(target_specialty)]

# class
class Technician:
    def __init__(self, name, specialty):
        self.name = name
        self.specialty = specialty

    def matches_specialization(self, target_specialty):
        return self.specialty == target_specialty

#sample usage
print("=== Load technicians from CSV ===")
technicians = load_technicians_from_csv("technicians.csv")
print("=== Filter technicians by specialty ===")
print("ใครเป็น ELectrical Technician:" , [tech.name for tech in filter_technicians_by_specialty(technicians, "Electrical")])
print("ใครเป็น Mechanical Technician:" , [tech.name for tech in filter_technicians_by_specialty(technicians, "Mechanical")])

print("=== Edge case: specialty not found ===")
print("ใครเป็น Plumbing Technician:" , [tech.name for tech in filter_technicians_by_specialty(technicians, "Plumbing")])